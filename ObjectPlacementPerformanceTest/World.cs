using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

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

		//protected abstract void moveObject (Actor actor, int x, int y);
		public abstract void removeObejct(Actor actor);

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

			return chosenActors.ToList();
		}

		public void testSinglePoint()
		{
			var list = getObjectsAt (NWidth / 2, NHeight / 2);
			list.ForEach(a => {removeObejct(a); addObject(a, a.X+1, a.Y+1);});
			list.ForEach(a => {removeObejct(a); addObject(a, a.X-1, a.Y-1);});
		}
		public void testRect()
		{
			var list = getObjectsAt (NWidth / 4, NHeight / 4, NWidth / 8, NHeight / 8);
			list.ForEach(a => {removeObejct(a); addObject(a, a.X+1, a.Y+1);});
			list.ForEach(a => {removeObejct(a); addObject(a, a.X-1, a.Y-1);});
		}
		public void testId(int maxId)
		{
			var list = getObjects ().Where (a => a.Id < maxId).ToList ();
			list.ForEach(a => {removeObejct(a); addObject(a, a.X+1, a.Y+1);});
			list.ForEach(a => {removeObejct(a); addObject(a, a.X-1, a.Y-1);});
		}

	}
}

