using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public abstract class World
	{
		int nWidth;

		public int NWidth {
			get {
				return nWidth;
			}
		}

		int nHeight;

		public int NHeight {
			get {
				return nHeight;
			}
		}

		public World(int nWidth, int nHeight)
		{
			this.nWidth = nWidth;
			this.nHeight = nHeight;
		}

		public void abbObject (Actor actor)
		{
			addObject (actor, actor.X, actor.Y);
		}
		public abstract void addObject (Actor actor, int x, int y);
		public abstract List<Actor> getObjects ();
		public abstract List<Actor> getObjectsAt(int x, int y);
		public List<Actor> getObjectsAt(int x, int y, int width, int height)
		{
			HashSet<Actor> chosenActors = new HashSet<Actor> ();
			for( int i=x; i < x+width; i++)
			{	
				for( int j=y; j < y+height; j++)
				{
					getObjectsAt (i, j).ForEach (a => chosenActors.Add (a));
				}
			}
			List<Actor> theseActors = new List<Actor> ();

			foreach (var a in chosenActors)
				theseActors.Add (a);

			return theseActors;
		}

		public void testSinglePoint()
		{
			getObjectsAt (NWidth / 2, nHeight / 2).ForEach(a => a.setLocation(a.X+1, a.Y+1));
			getObjectsAt (NWidth / 2+1, nHeight / 2+1).ForEach(a => a.setLocation(a.X-1, a.Y-1));
		}
		public void testRect()
		{
			getObjectsAt (NWidth / 4, nHeight / 4, NWidth/8, NHeight/8).ForEach(a => a.setLocation(a.X+1, a.Y+1));
			getObjectsAt (NWidth / 4+1, nHeight / 4+1, NWidth/8, NHeight/8).ForEach(a => a.setLocation(a.X-1, a.Y-1));
		}
		public void testId(int maxId)
		{
			getObjects().Where(a => a.Id < maxId).ToList().ForEach(a => a.setLocation(a.X+1, a.Y+1));
			getObjects().Where(a => a.Id < maxId).ToList().ForEach(a => a.setLocation(a.X-1, a.Y-1));
		}

	}
}

