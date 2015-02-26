using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace ObjectPlacementPerformanceTest
{
	public class ListModel : World
	{
		List<Actor> actorList;
		Dictionary<int, Actor> allActors;

		public ListModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			actorList = new List<Actor> ();
			allActors = new Dictionary<int, Actor> ();
		}

		#region implemented abstract members of ObjectContainer
		public override void addObject (Actor actor, int x, int y)
		{
			actor.setLocation (x, y);

			actorList.Add (actor);
			allActors.Add (actor.Id, actor);
		}
		public override List<Actor> getObjectsAt (int x, int y)
		{
			return actorList.Where (actor => actor.getRect ().Contains (new Point (x, y))).ToList();
		}
		public override List<Actor> getObjects ()
		{
			return actorList;
		}
		public override void removeObejct (Actor actor)
		{
			actorList.Remove (actor);
			allActors.Remove (actor.Id);
		}
		#endregion
	}
}