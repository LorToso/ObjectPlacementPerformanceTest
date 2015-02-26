using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace ObjectPlacementPerformanceTest
{
	public class MapMapModel : World
	{
		Dictionary<Point, HashSet<Actor>> map;
		Dictionary<int, Actor> allActors;

		public MapMapModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			map = new Dictionary<Point, HashSet<Actor>> ();
			allActors = new Dictionary<int, Actor> ();

			fillMap();
		}
		private void fillMap()
		{	
			for (int w = 0; w < NWidth; w++) {
				for (int h = 0; h < NHeight; h++) {
					map.Add (new Point(w,h), new HashSet<Actor>());
				}
			}
		}


		#region implemented abstract members of ObjectContainer
		public override void addObject (Actor actor, int x, int y)
		{
			actor.setLocation (x, y);
			for (int w=0; w < actor.Width; w++) {
				for (int h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					Point p = new Point (x + w, y + h);
					map[p].Add (actor);
				}
			}
			allActors.Add (actor.Id, actor);
		}
		public override List<Actor> getObjectsAt (int x, int y)
		{
			Point p = new Point (x, y);
			if(map.ContainsKey(p))
				return map[p].ToList();
			else return new List<Actor>();
		}
		public override List<Actor> getObjects ()
		{
			return allActors.Values.ToList();
		}
		public override void removeObejct (Actor actor)
		{
			int x = actor.X;
			int y = actor.Y;
			for (int w=0; w < actor.Width; w++) {
				for (int h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					map[new Point(x+w, y+h)].Remove(actor);
				}
			}
			allActors.Remove (actor.Id);
		}
		#endregion
	}
}

