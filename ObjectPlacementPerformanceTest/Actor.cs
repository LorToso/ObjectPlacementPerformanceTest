using System;
using System.Drawing;

namespace ObjectPlacementPerformanceTest
{
	public class Actor
	{
	    public double X { get; private set; }

        public double Y { get; private set; }

	    public int Width { get; private set; }

	    public int Height { get; private set; }

	    public int Id { get; private set; }

	    private static int _idCount;

	    public static Actor CreateWithRandomSize(int maxWidth, int maxHeight)
	    {
            var actor = new Actor();
            var random = new Random();
            actor.Width = random.Next(maxWidth);
            actor.Height = random.Next(maxHeight);
	        return actor;
	    }

		protected Actor()
		{
			Id = _idCount;
			_idCount++;
		}

        public void SetLocation(double x, double y)
		{
			X = x;
			Y = y;
		}
		public Rectangle GetRect()
		{
			return new Rectangle ((int) X,(int) Y,Width, Height);
		}

	    public bool IsInRect(Rectangle rectangle)
	    {
	        return GetRect().IntersectsWith(rectangle);
	    }
	}
}

