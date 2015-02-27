using System.Collections.Generic;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class MatrixModel : World
	{
	    readonly List<Actor>[,] _matrix;
	    readonly Dictionary<int, Actor> _allActors;

		public MatrixModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			_matrix = new List<Actor>[nWidth, nHeight];
			_allActors = new Dictionary<int, Actor> ();

			for (int w = 0; w < nWidth; w++) {
				for (int h = 0; h < nHeight; h++) {
					_matrix [w, h] = new List<Actor> ();
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
					_matrix [x+w, y+h].Add (actor);
				}
			}
			_allActors.Add (actor.Id, actor);
		}
		public override List<Actor> GetObjectsAt (int x, int y)
		{
			return _matrix [x, y];
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
					_matrix [x+w, y+h].Remove (actor);
				}
			}
			_allActors.Remove (actor.Id);
		}
		#endregion
	}
}

