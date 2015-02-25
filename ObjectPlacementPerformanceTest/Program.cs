using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;

namespace ObjectPlacementPerformanceTest
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			int nObjectCount = 100;
			int nWidth = 1000;
			int nHeight = 1000;

			Console.WriteLine ("Start!");
			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			World matrixModel = new MatrixModel (nWidth, nHeight);
			stopWatch.Stop ();
			Console.WriteLine ("Creating MatrixModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();
			World mapModel = new MapModel (nWidth, nHeight);
			stopWatch.Stop ();
			Console.WriteLine ("Creating MapModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();


			List<Actor> newActors = new List<Actor> ();

			Random random = new Random ();
			for (int i=0; i < nObjectCount; i++) {
				Actor actor = new Actor (nWidth, nHeight);
				int x = random.Next (nWidth);
				int y = random.Next (nHeight);
				actor.setLocation (x, y);
				newActors.Add (actor);
			}
			
			stopWatch.Stop ();
			Console.WriteLine ("Creating Objects took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();

			foreach(Actor a in newActors){
				matrixModel.abbObject (a);
			}
			
			stopWatch.Stop ();
			Console.WriteLine ("Adding Objects to MatrixModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();

			foreach(Actor a in newActors){
				mapModel.abbObject (a);
			}

			stopWatch.Stop ();
			Console.WriteLine ("Adding Objects to MapModel took " + stopWatch.ElapsedMilliseconds + " ms");
			stopWatch.Restart ();


			int executionTimes = 1;

			Console.Out.WriteLine ("Starting Tests!");
			Console.Out.WriteLine ("World Size: " + nWidth + "x" + nHeight);
			Console.Out.WriteLine ("ActorCount: " + nObjectCount);
			Console.Out.WriteLine ("ExecutionTimes: " + executionTimes);
			Console.Out.WriteLine ("MapModel:");

			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				mapModel.testSinglePoint ();
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionTimes +  " SingleTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				mapModel.testRect ();
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionTimes +  " RectTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				mapModel.testId (nObjectCount/2);
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionTimes +  " IdTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();


			Console.Out.WriteLine ("MatixModel:");
			
			for (int i = 0; i < executionTimes; i++) {
				matrixModel.testSinglePoint ();
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionTimes +  " SingleTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				matrixModel.testRect ();
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionTimes +  " RectTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();
			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				matrixModel.testId (nObjectCount/2);
			}
			stopWatch.Stop ();
			Console.Out.WriteLine (executionTimes +  " IdTests: " + stopWatch.ElapsedMilliseconds +"ms");
			stopWatch.Reset ();

			System.Threading.Thread.Sleep (100000);
		}
	}
}
