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
            TestParameter testParameter = new TestParameter(100000,100,100);
			
            
		    var types = new[] {typeof (MatrixModel), typeof (MapListModel), typeof (MapMapModel), typeof (ListModel)};


		    Test(testParameter, types);


			Thread.Sleep (1000000);
		}

	    internal class TestParameter
	    {
	        public TestParameter(int objectCount, int width, int height)
            {
                ObjectCount = objectCount;
                Width = width;
                Height = height;
	        }

            public int Width { get; set; }
            public int Height { get; set; }
            public int ObjectCount { get; set; }
	    }

	    private static void Test(TestParameter testParameter, IList<Type> types)
        {
            const int executionCount = 1;
            const int testCount = 5;

	        var times = new long[types.Count, executionCount, testCount];

	        var allWorlds = new World[types.Count];


            InitWorlds(allWorlds, testParameter.Width, testParameter.Height , types, times);

	        for (var execution=0; execution < executionCount; execution++)
	        {
	            for (var worldIndex = 0; worldIndex < allWorlds.Length; worldIndex++)
	            {
	                TestWorld(testParameter, allWorlds, worldIndex, times, execution);
	            }
	        }
	        ValidateResults(times,allWorlds);
        }

	    private static void ValidateResults(long[,,] times, World[] worlds)
	    {
	        var normizedTimes = new long[times.GetLength(0), times.GetLength(2)];

	        for (var worldIndex = 0; worldIndex < times.GetLength(0); worldIndex++)
            {
                for (var testIndex = 0; testIndex < times.GetLength(2); testIndex++)
                {
                    long testTime = 0;
                    for (var executionIndex = 0; executionIndex < times.GetLength(1); executionIndex++)
                    {
                        testTime += times[worldIndex, executionIndex, testIndex];
                    }
                    testTime /= times.GetLength(1);
                    normizedTimes[worldIndex, testIndex] = testTime;

                    Console.WriteLine(worlds[worldIndex].GetType().Name + "; Test " + testIndex + " took " + testTime + "ms on average");
                }   
	        }


	    }

	    private static void TestWorld(TestParameter testParameter, World[] allWorlds, int worldIndex, long[,,] times,
	        int execution)
	    {
	        var world = allWorlds[worldIndex];
            var newActors = InitActors(testParameter);

	        var localTimes = TestWorld(world, newActors);

	        for (var timeIndex = 0; timeIndex < localTimes.Length; timeIndex++)
	        {
	            times[worldIndex, execution, timeIndex + 1] = localTimes[timeIndex];
	        }

	        world.Reset();
	    }

        private static List<Actor> InitActors(TestParameter testParameter)
	    {
	        var newActors = new List<Actor>();

	        var random = new Random();
            for (var i = 0; i < testParameter.ObjectCount; i++)
	        {
                var actor = new Actor(testParameter.Width, testParameter.Height);
                var x = random.Next(testParameter.Width);
                var y = random.Next(testParameter.Height);
	            actor.SetLocation(x, y);
	            newActors.Add(actor);
	        }
	        return newActors;
	    }

	    private static void InitWorlds(IList<World> allWorlds, int width, int height, IList<Type> types, long[,,] times)
	    {
	        var stopWatch = new Stopwatch();

            for (var i = 0; i < types.Count; i++)
            {
                var world = (World)Activator.CreateInstance(types[i]);

                stopWatch.Restart();

                world.SetSize(width, height);
                world.Init();
                allWorlds[i] = world;

                stopWatch.Stop();
                times[i, 0, 0] = stopWatch.ElapsedMilliseconds;
                Console.WriteLine("Init world " + types[i].Name + " took " + times[i,0,0] + "ms");
            }
	    }

	    static long[] TestWorld(World world, ICollection<Actor> newActors)
	    {
	        var localTimes = new long[4];
			var stopWatch = new Stopwatch ();
			stopWatch.Start ();

			foreach(var a in newActors){
				world.AbbObject (a);
			}

			stopWatch.Stop ();
            localTimes[0] = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Adding Objects to " + world.GetType().Name + " took " + localTimes[0] + "ms");
            stopWatch.Restart ();
            
			world.TestSinglePoint ();

            stopWatch.Stop();
            localTimes[1] = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Position-Test for " + world.GetType().Name + " took " + localTimes[1] + "ms");
            stopWatch.Restart();
            
			world.TestRect ();

            stopWatch.Stop();
            localTimes[2] = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Rect-Test for " + world.GetType().Name + " took " + localTimes[2] + "ms");
            stopWatch.Restart();

			world.TestId (newActors.Count/2);

            stopWatch.Stop();
            localTimes[3] = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("ID-Test for " + world.GetType().Name + " took " + localTimes[3] + "ms");
            stopWatch.Restart();

	        return localTimes;
	    }
	}
}
