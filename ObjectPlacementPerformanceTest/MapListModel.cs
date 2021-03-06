using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class MapListModel : World
	{
	    Dictionary<Point, List<Actor>> _map;
	    Dictionary<int, Actor> _allActors;


		#region implemented abstract members of ObjectContainer
        public override void AddObject(Actor actor, double x, double y)
		{
			actor.SetLocation (x, y);
			for (var w=0; w < actor.Width; w++) {
				for (var h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					var p = new Point ((int) (x + w), (int) (y + h));
					_map[p].Add (actor);
				}
			}
			_allActors.Add (actor.Id, actor);
		}
		public override List<Actor> GetObjectsAt (int x, int y)
		{
		    var p = new Point (x, y);
		    return _map.ContainsKey(p) ? _map[p] : new List<Actor>();
		}

	    public override List<Actor> GetObjectsAt(int x, int y, int width, int height)
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

	    public override void Init()
        {
            _map = new Dictionary<Point, List<Actor>>();
            _allActors = new Dictionary<int, Actor>();

            for (var w = 0; w < NWidth; w++)
            {
                for (var h = 0; h < NHeight; h++)
                {
                    _map.Add(new Point(w, h), new List<Actor>());
                }
            }
	    }

	    public override void Reset()
	    {
	        Init();
	    }

	    public override void MoveObject(Actor actor, double x, double y)
        {
            RemoveObject(actor);
            AddObject(actor, x, y);
	    }

	    public override List<Actor> GetObjects ()
		{
			return _allActors.Values.ToList();
		}
		public override void RemoveObject (Actor actor)
		{
			var x = actor.X;
            var y = actor.Y;
            for (var w = 0; w < actor.Width; w++)
            {
                for (var h = 0; h < actor.Height; h++)
                {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					_map[new Point((int) (x+w), (int) (y+h))].Remove(actor);
				}
			}
			_allActors.Remove (actor.Id);
		}
		#endregion
	}
}

