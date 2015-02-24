using System;

namespace ObjectPlacementPerformanceTest
{
	public class Actor
	{
		private int x { get; set; }
		private int y { get; set; }
		private int id;

		public int getId {
			get {
				return id;
			}
		}

		private static int idCount = 0;

		public Actor()
		{
			id = idCount;
			idCount++;
		}

		public void setLocation(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

	}
}

