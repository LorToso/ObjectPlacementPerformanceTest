# ObjectPlacementPerformanceTest
This Project compares performance of saving (and visiting) a big number of Objects in different Containers.

# Object properties
The stored objects represent simple structures that have coordinates and a certain size.

# Tested performance
A certain amount of objects is created and stored within different data-structures. The tested performance consists in creating and storing a big number of objects in containers of different sizes. Later it is tried to perform various actions on the stored object, such as moving them or changing their size.

# Tested containers
MapModel: Stores objects into a Dictionary of Lists (Dictionary<Point, List<Actor>>) using a Point that describes their coordinates as Key. Since the objects have a certain size, it is necessary to add an object to the model on every point it is placed on.

MatrixModel: Stores objects in a two dimensional array of Lists (List<Actor>[][]). An object is added to every list it partially overlaps with.
