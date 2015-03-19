using System.Collections.Generic;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class MatrixModel : World
	{
	    List<Actor>[,] _matrix;
	    Dictionary<int, Actor> _allActors;

		#region implemented abstract members of ObjectContainer
        public override void AddObject(Actor actor, double x, double y)
		{
			actor.SetLocation (x, y);
            for (var w = 0; w < actor.Width; w++)
            {
				for (var h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					_matrix [(int) (x+w), (int) (y+h)].Add (actor);
				}
			}
			_allActors.Add (actor.Id, actor);
		}
		public override List<Actor> GetObjectsAt (int x, int y)
		{
			return _matrix [x, y];
		}

        public override List<Actor> GetObjectsAt(int x, int y, int width, int height)
        {
            var chosenActors = new HashSet<Actor>();
            for (var i = x; i < x + width; i++)
            {
                for (var j = y; j < y + height; j++)
                {
                    GetObjectsAt(i, j).ForEach(a => chosenActors.Add(a));
                }
            }

            return chosenActors.ToList();
        }

	    public override void Init()
        {
            _matrix = new List<Actor>[NWidth, NHeight];
            _allActors = new Dictionary<int, Actor>();

            for (var w = 0; w < NWidth; w++)
            {
                for (var h = 0; h < NHeight; h++)
                {
                    _matrix[w, h] = new List<Actor>();
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
			for (var w=0; w < actor.Width; w++) {
				for (var h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					_matrix [(int) (x+w), (int) (y+h)].Remove (actor);
				}
			}
			_allActors.Remove (actor.Id);
		}
		#endregion
	}
}

