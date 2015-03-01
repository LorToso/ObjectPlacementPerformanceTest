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

MatrixListModel:
Creating Map: 147ms | 153ms | 143ms
Adding Objects: 2099ms | 44ms | 899ms
PositionTest: 1081ms | 2ms | 79ms
RectTest: 990,21ms | 4ms | 282ms
IDTest: 2600,15ms | 27ms | 830ms

MapListModel:
Creating Map: 28071ms | 30394ms | 27697ms
Adding Objects: 235962ms | 8461ms | 125499ms
PositionTest: Xms | 283ms | 
RectTest: Xms | 2593ms
IDTest: Xms | 16058ms 

MapMapModel:
Creating Map: 29035ms | 29155ms | 27408ms
Adding Objects: Xms | 8461ms
PositionTest: Xms | 297ms
RectTest: Xms | 2593ms
IDTest: Xms | 15674ms

ListModel:
Creating Map: 0ms | 0ms | 0ms
Adding Objects: Xms | 0ms
PositionTest: Xms | 0ms 
RectTest: Xms | 46ms
IDTest: Xms | 0ms

