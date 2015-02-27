using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class ListModel : World
	{
	    readonly List<Actor> _actorList;
	    readonly Dictionary<int, Actor> _allActors;

		public ListModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			_actorList = new List<Actor> ();
			_allActors = new Dictionary<int, Actor> ();
		}

		#region implemented abstract members of ObjectContainer
		public override void AddObject (Actor actor, int x, int y)
		{
			actor.SetLocation (x, y);

			_actorList.Add (actor);
			_allActors.Add (actor.Id, actor);
		}
		public override List<Actor> GetObjectsAt (int x, int y)
		{
			return _actorList.Where (actor => actor.GetRect ().Contains (new Point (x, y))).ToList();
		}
		public override List<Actor> GetObjects ()
		{
			return _actorList;
		}
		public override void RemoveObejct (Actor actor)
		{
			_actorList.Remove (actor);
			_allActors.Remove (actor.Id);
		}
		#endregion
	}
}