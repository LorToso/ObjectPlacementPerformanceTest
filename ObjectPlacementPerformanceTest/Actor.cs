using System;
using System.Drawing;

namespace ObjectPlacementPerformanceTest
{
	public class Actor
	{
		private int x;

		public int X {
			get {
				return x;
			}
		}

		private int y;

		public int Y {
			get {
				return y;
			}
		}

		private int width;

		public int Width {
			get {
				return width;
			}
		}

		private int height;

		public int Height {
			get {
				return height;
			}
		}

		private int id;

		public int Id {
			get {
				return id;
			}
		}

		private static int idCount = 0;

		public Actor(World world)
			:this (world.NWidth, world.NHeight)
		{
		}
		public Actor(int worldWidth, int worldHeight)
		{
			Random random = new Random ();
			width = random.Next (worldWidth/2);
			height = random.Next (worldHeight/2);
			id = idCount;
			idCount++;
		}

		public void setLocation(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public Rectangle getRect()
		{
			return new Rectangle (x,y,width, height);
		}

	}
}

