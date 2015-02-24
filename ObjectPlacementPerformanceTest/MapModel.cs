using System;

namespace ObjectPlacementPerformanceTest
{
	public class MapModel : ObjectContainer
	{
		public MapModel(int nWidth, int nHeight)
			:base(nWidth, nHeight)
		{
		}

		#region implemented abstract members of ObjectContainer
		public override void addObject (Actor actor, int x, int y)
		{
			throw new NotImplementedException ();
		}
		public override void removeObject (Actor actor)
		{
			throw new NotImplementedException ();
		}
		public override System.Collections.Generic.List<Actor> getObjectsAt (int x, int y)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

