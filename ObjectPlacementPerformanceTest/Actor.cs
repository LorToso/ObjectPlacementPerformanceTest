using System;
using System.Drawing;

namespace ObjectPlacementPerformanceTest
{
	public class Actor
	{
	    public int X { get; private set; }

	    public int Y { get; private set; }

	    private readonly int _width;

		public int Width {
			get {
				return _width;
			}
		}

		private readonly int _height;

		public int Height {
			get {
				return _height;
			}
		}

		private readonly int _id;

		public int Id {
			get {
				return _id;
			}
		}

		private static int _idCount;

		public Actor(World world)
			:this (world.NWidth, world.NHeight)
		{
		}
		public Actor(int worldWidth, int worldHeight)
		{
			Random random = new Random ();
			_width = random.Next (worldWidth/2);
			_height = random.Next (worldHeight/2);
			_id = _idCount;
			_idCount++;
		}

		public void SetLocation(int x, int y)
		{
			X = x;
			Y = y;
		}
		public Rectangle GetRect()
		{
			return new Rectangle (X,Y,_width, _height);
		}

	}
}

