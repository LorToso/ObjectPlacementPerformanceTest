using System;

namespace ObjectPlacementPerformanceTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Start!");

			int nObjectCount = 1000;



			Console.WriteLine ("Adding " + nObjectCount + " Objects!");


			System.Threading.Thread.Sleep (5000);
		}
	}
}
