using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace ObjectPlacementPerformanceTest
{
	public class MapModel : World
	{
		Dictionary<Point, List<Actor>> map;

		public MapModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			map = new Dictionary<Point, List<Actor>> ();
		}

		#region implemented abstract members of ObjectContainer
		public override void addObject (Actor actor, int x, int y)
		{
			for (int w=0; w < actor.Width; w++) {
				for (int h=0; h < actor.Height; h++) {

					Point p = new Point (x + w, y + h);

					List<Actor> elementList;
					if (!map.ContainsKey (p)) {
						elementList = new List<Actor> ();
						map.Add (p, elementList);
					} else {
						elementList = map[p];
					}

					elementList.Add (actor);
				}
			}
		}
		public override List<Actor> getObjectsAt (int x, int y)
		{
			Point p = new Point (x, y);
			if(map.ContainsKey(p))
				return map[p];
			else return new List<Actor>();
		}
		public override List<Actor> getObjects ()
		{
			List<Actor> allActors = new List<Actor> ();
			foreach (var keyValuePair in map.ToList ()) {
				keyValuePair.Value.ForEach(element => allActors.Add(element));
			}
			return  allActors;
		}
		#endregion
	}
}

