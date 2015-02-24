using System;

namespace ObjectPlacementPerformanceTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Start!");

			int nObjectCount = 1000;
			int nWidth = 1000;
			int nHeight = 1000;


			ObjectContainer matrixModel = new MatrixModel (nWidth, nHeight);
			ObjectContainer mapModel = new MapModel (nWidth, nHeight);

			Console.WriteLine ("Adding " + nObjectCount + " Objects!");

			for (int i=0; i < nObjectCount; i++) {
				Actor actor = new Actor ();
				int x = new Random ().Next (nWidth);
				int y = new Random ().Next (nHeight);
				matrixModel.addObject (actor, x, y);
				mapModel.addObject (actor, x, y);
			}



			System.Threading.Thread.Sleep (5000);
		}
	}
}
