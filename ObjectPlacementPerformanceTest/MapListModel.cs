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
		public override void AddObject (Actor actor, int x, int y)
		{
			actor.SetLocation (x, y);
			for (int w=0; w < actor.Width; w++) {
				for (int h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					Point p = new Point (x + w, y + h);
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

	    public override List<Actor> GetObjects ()
		{
			return _allActors.Values.ToList();
		}
		public override void RemoveObejct (Actor actor)
		{
			int x = actor.X;
			int y = actor.Y;
			for (int w=0; w < actor.Width; w++) {
				for (int h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					_map[new Point(x+w, y+h)].Remove(actor);
				}
			}
			_allActors.Remove (actor.Id);
		}
		#endregion
	}
}

