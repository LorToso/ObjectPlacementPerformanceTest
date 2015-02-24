using System;

namespace ObjectPlacementPerformanceTest
{
	public abstract class ObjectContainer
	{
		public abstract void addObject (Actor actor);
		public abstract void removeObject (Actor actor);
		public abstract void visitObject (Actor actor);
		public abstract void visitAllObjects ();
	}
}

