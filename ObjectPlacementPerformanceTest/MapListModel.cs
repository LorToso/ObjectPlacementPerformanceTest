using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class MapListModel : World
	{
	    readonly Dictionary<Point, List<Actor>> _map;
	    readonly Dictionary<int, Actor> _allActors;

		public MapListModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			_map = new Dictionary<Point, List<Actor>> ();
			_allActors = new Dictionary<int, Actor> ();

			for (int w = 0; w < nWidth; w++) {
				for (int h = 0; h < nHeight; h++) {
					_map.Add (new Point(w,h), new List<Actor>());
				}
			}
		}

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
			Point p = new Point (x, y);
			if(_map.ContainsKey(p))
				return _map[p];
			else return new List<Actor>();
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

