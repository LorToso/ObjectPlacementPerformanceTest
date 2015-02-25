using System;
using System.Diagnostics;

namespace ObjectPlacementPerformanceTest
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			Console.WriteLine ("Start!");

			int nObjectCount = 4000;
			int nWidth = 200;
			int nHeight = 200;


			World matrixModel = new MatrixModel (nWidth, nHeight);
			World mapModel = new MapModel (nWidth, nHeight);

			//Console.WriteLine ("Adding " + nObjectCount + " Objects);
			
			Random random = new Random ();
			for (int i=0; i < nObjectCount; i++) {
				Actor actor = new Actor (nWidth, nHeight);
				int x = random.Next (nWidth);
				int y = random.Next (nHeight);
				matrixModel.addObject (actor, x, y);
				mapModel.addObject (actor, x, y);
				//Console.WriteLine ("Adding Object " + actor.Id + "at (" + x + "|" + y + "). Size + " + actor.Width + "x" + actor.Height);
			}

			int executionTimes = 1000;

			Console.Out.WriteLine ("Starting Tests!");
			Console.Out.WriteLine ("World Size: " + nWidth + "x" + nHeight);
			Console.Out.WriteLine ("ActorCount: " + nObjectCount);
			Console.Out.WriteLine ("ExecutionTimes: " + executionTimes);
			Console.Out.WriteLine ("MapModel:");

			Stopwatch stopWatch = new Stopwatch ();
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
