using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectPlacementPerformanceTest
{
	public class MatrixModel : World
	{

		List<Actor>[,] matrix;
		Dictionary<int, Actor> allActors;

		public MatrixModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			matrix = new List<Actor>[nWidth, nHeight];
			allActors = new Dictionary<int, Actor> ();

			for (int w = 0; w < nWidth; w++) {
				for (int h = 0; h < nHeight; h++) {
					matrix [w, h] = new List<Actor> ();
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
					matrix [x+w, y+h].Add (actor);
				}
			}
			allActors.Add (actor.Id, actor);
		}
		public override List<Actor> getObjectsAt (int x, int y)
		{
			return matrix [x, y];
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
					matrix [x+w, y+h].Remove (actor);
				}
			}
			allActors.Remove (actor.Id);
		}
		#endregion
	}
}

