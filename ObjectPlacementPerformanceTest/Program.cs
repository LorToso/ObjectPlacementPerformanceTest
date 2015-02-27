using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ObjectPlacementPerformanceTest
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			const int nObjectCount = 100;
			const int nWidth = 1000;
			const int nHeight = 1000;

			Console.WriteLine ("Start!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			World[] allWorlds = new World[2];


			allWorlds[1] = new MatrixModel (nWidth, nHeight);

			stopWatch.Stop ();
			Console.WriteLine ("Creating MatrixModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();

			/*allWorlds[1] = new MapListModel (nWidth, nHeight);

			stopWatch.Stop ();
			Console.WriteLine ("Creating MapListModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();
			
			allWorlds[1] = new MapMapModel (nWidth, nHeight);

			stopWatch.Stop ();
			Console.WriteLine ("Creating MapMapModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();
			*/
			
			allWorlds[0] = new ListModel (nWidth, nHeight);

			stopWatch.Stop ();
			Console.WriteLine ("Creating ListModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();

			List<Actor> newActors = new List<Actor> ();

			Random random = new Random ();
			for (int i=0; i < nObjectCount; i++) {
				Actor actor = new Actor (nWidth, nHeight);
				int x = random.Next (nWidth);
				int y = random.Next (nHeight);
				actor.SetLocation (x, y);
				newActors.Add (actor);
			}
			
			stopWatch.Stop ();
			Console.WriteLine ("Creating Objects took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();

			
			stopWatch.Stop ();
			Console.WriteLine ("Adding Objects to MatrixModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();


			
			const int executionCount = 100;

			Console.Out.WriteLine ("Starting Tests!");
			Console.Out.WriteLine ("World Size: " + nWidth + "x" + nHeight);
			Console.Out.WriteLine ("ActorCount: " + nObjectCount);
			Console.Out.WriteLine ("ExecutionCount: " + executionCount);

			foreach (World w in allWorlds) {
				TestWorld (w, newActors, executionCount);
			}

			Thread.Sleep (100000);
		}
		static void TestWorld(World world, List<Actor> newActors, int executionCount)
		{
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();
			String name = world.GetType ().Name;

			Console.Out.WriteLine (name + ":");

			foreach(Actor a in newActors){
				world.AbbObject (a);
			}

			stopWatch.Stop ();
			Console.WriteLine ("Adding Objects to " + name + " took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();


			for (int i = 0; i < executionCount; i++) {
				world.TestSinglePoint ();
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionCount +  " SingleTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
			stopWatch.Start ();

			for (int i = 0; i < executionCount; i++) {
				world.TestRect ();
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionCount +  " RectTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
			stopWatch.Start ();

			for (int i = 0; i < executionCount; i++) {
				world.TestId (newActors.Count/2);
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionCount +  " IdTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
		}
	}
}
