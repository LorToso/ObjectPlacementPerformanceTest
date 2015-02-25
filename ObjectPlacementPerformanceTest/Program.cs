using System;
using System.Diagnostics;

namespace ObjectPlacementPerformanceTest
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			Console.WriteLine ("Start!");

			int nObjectCount = 1000;
			int nWidth = 100;
			int nHeight = 100;


			World matrixModel = new MatrixModel (nWidth, nHeight);
			World mapModel = new MapModel (nWidth, nHeight);

			
			Random random = new Random ();
			for (int i=0; i < nObjectCount; i++) {
				Actor actor = new Actor (nWidth, nHeight);
				int x = random.Next (nWidth);
				int y = random.Next (nHeight);
				matrixModel.addObject (actor, x, y);
				mapModel.addObject (actor, x, y);
				Console.WriteLine ("Adding Object " + actor.Id + "at (" + x + "|" + y + "). Size + " + actor.Width + "x" + actor.Height);
			}

			int executionTimes = 100;

			Console.Out.WriteLine ("Starting Tests!");
			Console.Out.WriteLine ("World Size: " + nWidth + "x" + nHeight);
			Console.Out.WriteLine ("ActorCount: " + nObjectCount);
			Console.Out.WriteLine ("ExecutionTimes: " + executionTimes);
			Console.Out.WriteLine ("MapModel:");

			Stopwatch stopWatch = new Stopwatch ();
			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				mapModel.testSinglePoint ();
				mapModel.testRect ();
				mapModel.testId (nObjectCount/2);
			}
			stopWatch.Stop ();
			
			Console.Out.WriteLine ("Elapsed Time in ms: " + stopWatch.ElapsedMilliseconds);
			stopWatch.Reset ();
			
			Console.Out.WriteLine ("MatixModel:");
			stopWatch.Start ();

			for (int i = 0; i < executionTimes; i++) {
				matrixModel.testSinglePoint ();
				matrixModel.testRect ();
				matrixModel.testId (nObjectCount/2);
			}
			stopWatch.Stop ();

			Console.Out.WriteLine ("Elapsed Time in ms: " + stopWatch.ElapsedMilliseconds);
			stopWatch.Reset ();

			System.Threading.Thread.Sleep (10000);
		}
	}
}
