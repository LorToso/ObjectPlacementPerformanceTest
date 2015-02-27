# ObjectPlacementPerformanceTest
This Project compares performance of saving (and visiting) a big number of Objects in different Containers.

# Object properties
The stored objects represent simple structures that have coordinates and a certain size.

# Tested performance
A certain amount of objects is created and stored within different data-structures. The tested performance consists in creating and storing a big number of objects in containers of different sizes. Later it is tried to perform various actions on the stored object, such as moving them or changing their size.

Tests:
1. Adding Objects to random locations
2. PositionTest: Selecting all Objects at a given location. Removing and readding them.
3. RectTest: Selecting all Objects in a given rectangle. Removing and readding them.
4. IDTest: Selecting all Objects with a certain ID-Range. Removing and readding them.

# Tested containers
MapListModel: Stores objects into a Dictionary of Lists (Dictionary<Point, List<Actor>>) using a Point that describes their coordinates as Key. Since the objects have a certain size, it is necessary to add an object to the model on every point it is placed on.

MatrixListModel: Stores objects in a two dimensional array of Lists (List<Actor>[][]). An object is added to every list it partially overlaps with.

MapMapModel: Same as MapListModel, but has a Dictionary of Dictionaries ( Dictionary<Point, Dictionary<Actor>>)

ListModel: Stores objects in a simple List of objects (List<Actor>). To search for a certain object it is necessary to go through all the list.

# TestResult
World size: 1000x1000
ObjectCount: 100 
ExecutionCount for each test: 100

MatrixListModel:
Creating Map: 147ms
Adding Objects: 2099ms
PositionTest: 108100ms
RectTest: 99021ms
IDTest: 260015ms

MapListModel:
Creating Map: 28071ms
Adding Objects: 235962ms
PositionTest: Xms
RectTest: Xms
IDTest: Xms

MapMapModel:
Creating Map: 29035ms
Adding Objects: Xms
PositionTest: Xms
RectTest: Xms
IDTest: Xms

ListModel:
Creating Map: 0ms
Adding Objects: Xms
PositionTest: Xms
RectTest: Xms
IDTest: Xms

