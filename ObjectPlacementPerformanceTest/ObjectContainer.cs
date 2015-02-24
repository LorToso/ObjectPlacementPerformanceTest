using System;
using System.Collections.Generic;

namespace ObjectPlacementPerformanceTest
{
	public abstract class ObjectContainer
	{
		int nWidth;

		public int NWidth {
			get {
				return nWidth;
			}
		}

		int nHeight;

		public int NHeight {
			get {
				return nHeight;
			}
		}

		public ObjectContainer(int nWidth, int nHeight)
		{
			this.nWidth = nWidth;
			this.nHeight = nHeight;
		}

		public abstract void addObject (Actor actor, int x, int y);
		public abstract void removeObject (Actor actor);
		public abstract List<Actor> getObjectsAt(int x, int y);
	}
}

