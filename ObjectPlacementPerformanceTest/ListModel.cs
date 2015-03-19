using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class ListModel : World
	{
	    List<Actor> _actorList;
	    Dictionary<int, Actor> _allActors;


		#region implemented abstract members of ObjectContainer
        public override void AddObject(Actor actor, double x, double y)
		{
			actor.SetLocation (x, y);

			_actorList.Add (actor);
			_allActors.Add (actor.Id, actor);
		}
		public override List<Actor> GetObjectsAt (int x, int y)
		{
			return _actorList.Where (actor => actor.GetRect ().Contains (new Point (x, y))).ToList();
		}

	    public override List<Actor> GetObjectsAt(int x, int y, int width, int height)
	    {
	        return _actorList.Where(actor => actor.IsInRect(new Rectangle(x, y, width, height))).ToList();
	    }

	    public override void Init()
        {
            _actorList = new List<Actor>();
            _allActors = new Dictionary<int, Actor>();
	    }

	    public override void Reset()
	    {
	        Init();
	    }

	    public override void MoveObject(Actor actor, double x, double y)
	    {
            if(_actorList.Contains(actor))
                actor.SetLocation(x,y);
	    }

	    public override List<Actor> GetObjects ()
		{
			return _actorList;
		}
		public override void RemoveObject (Actor actor)
		{
			_actorList.Remove (actor);
			_allActors.Remove (actor.Id);
		}
		#endregion
	}
}