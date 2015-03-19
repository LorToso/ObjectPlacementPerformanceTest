using System.Collections.Generic;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public abstract class World
	{
	    public int NWidth { get; private set; }

	    public int NHeight { get; private set; }

	    protected World()
	    {
	    }

	    protected World(int nWidth, int nHeight)
		{
            SetSize(nWidth, nHeight);
            Init();
		}

		public void AbbObject (Actor actor)
		{
			AddObject (actor, actor.X, actor.Y);
		}
        public abstract void AddObject(Actor actor, double x, double y);

		public abstract void RemoveObject(Actor actor);

        public abstract void MoveObject(Actor actor, double x, double y);


		public abstract List<Actor> GetObjects ();
		public abstract List<Actor> GetObjectsAt(int x, int y);
	    public abstract List<Actor> GetObjectsAt(int x, int y, int width, int height);

		public void TestSinglePoint()
		{
			var list = GetObjectsAt (NWidth / 2, NHeight / 2);
			list.ForEach(a => { MoveObject(a, a.X + 1, a.Y + 1); });
			list.ForEach(a => { MoveObject(a, a.X - 1, a.Y - 1); });
		}
		public void TestRect()
		{
			var list = GetObjectsAt (NWidth / 4, NHeight / 4, NWidth / 8, NHeight / 8);
			list.ForEach(a => { MoveObject(a, a.X + 1, a.Y + 1); });
            list.ForEach(a => { MoveObject(a, a.X - 1, a.Y - 1); });
		}
		public void TestId(int maxId)
		{
			var list = GetObjects ().Where (a => a.Id < maxId).ToList ();
			list.ForEach(a => { MoveObject(a, a.X + 1, a.Y + 1); });
            list.ForEach(a => { MoveObject(a, a.X - 1, a.Y - 1); });
		}

	    public void SetSize(int width, int height)
        {
            NWidth = width;
            NHeight = height;
	    }

	    public abstract void Init();
	    public abstract void Reset();
	}
}

