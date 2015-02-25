using System;
using System.Collections.Generic;

namespace ObjectPlacementPerformanceTest
{
	public class MatrixModel : World
	{
		List<Actor>[,] matrix;
		public MatrixModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
			matrix = new List<Actor>[nWidth, nHeight];
			for (int w = 0; w < nWidth; w++) {
				for (int h = 0; h < nHeight; h++) {
					matrix [w, h] = new List<Actor> ();
				}
			}
		}

		#region implemented abstract members of ObjectContainer
		public override void addObject (Actor actor, int x, int y)
		{
			for (int w=0; w < actor.Width; w++) {
				for (int h=0; h < actor.Height; h++) {
					if (x + w >= NWidth)
						continue;
					if (y + h >= NHeight)
						continue;
					matrix [x+w, y+h].Add (actor);
				}
			}
		}
		public override List<Actor> getObjectsAt (int x, int y)
		{
			return matrix [x, y];
		}
		public override List<Actor> getObjects ()
		{
			HashSet<Actor> allObjects = new HashSet<Actor> ();
			List<Actor> allObjectList = new List<Actor> ();
			foreach (List<Actor> a in matrix)
				a.ForEach(element => allObjects.Add (element));
			foreach (Actor a in allObjects)
				allObjectList.Add (a);
			return allObjectList;
		}
		#endregion
	}
}

