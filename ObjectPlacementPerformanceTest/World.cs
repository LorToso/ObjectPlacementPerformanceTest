using System.Collections.Generic;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public abstract class World
	{
	    readonly int _nWidth;

		public int NWidth {
			get {
				return _nWidth;
			}
		}

	    readonly int _nHeight;

		public int NHeight {
			get {
				return _nHeight;
			}
		}

	    protected World(int nWidth, int nHeight)
		{
			_nWidth = nWidth;
			_nHeight = nHeight;
		}

		public void AbbObject (Actor actor)
		{
			AddObject (actor, actor.X, actor.Y);
		}
		public abstract void AddObject (Actor actor, int x, int y);

		//protected abstract void moveObject (Actor actor, int x, int y);
		public abstract void RemoveObejct(Actor actor);

		public abstract List<Actor> GetObjects ();
		public abstract List<Actor> GetObjectsAt(int x, int y);
		public List<Actor> GetObjectsAt(int x, int y, int width, int height)
		{
			HashSet<Actor> chosenActors = new HashSet<Actor> ();
			for( int i=x; i < x+width; i++)
			{	
				for( int j=y; j < y+height; j++)
				{
					GetObjectsAt (i, j).ForEach (a => chosenActors.Add (a));
				}
			}

			return chosenActors.ToList();
		}

		public void TestSinglePoint()
		{
			var list = GetObjectsAt (NWidth / 2, NHeight / 2);
			list.ForEach(a => {RemoveObejct(a); AddObject(a, a.X+1, a.Y+1);});
			list.ForEach(a => {RemoveObejct(a); AddObject(a, a.X-1, a.Y-1);});
		}
		public void TestRect()
		{
			var list = GetObjectsAt (NWidth / 4, NHeight / 4, NWidth / 8, NHeight / 8);
			list.ForEach(a => {RemoveObejct(a); AddObject(a, a.X+1, a.Y+1);});
			list.ForEach(a => {RemoveObejct(a); AddObject(a, a.X-1, a.Y-1);});
		}
		public void TestId(int maxId)
		{
			var list = GetObjects ().Where (a => a.Id < maxId).ToList ();
			list.ForEach(a => {RemoveObejct(a); AddObject(a, a.X+1, a.Y+1);});
			list.ForEach(a => {RemoveObejct(a); AddObject(a, a.X-1, a.Y-1);});
		}

	}
}

