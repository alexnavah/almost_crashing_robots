# almost_crashing_robots
Robots walking on a map based on instructiones given, but they might get lost... :'(

This is a code challenge based on the Martian Robots one.

# Running instructions

## Console application

```
$ dotnet run --project .\src\ConsoleApplication\ConsoleApplication.csproj -c Release
```

## REST Api application (docker)

```
In .\src\ApiApplication folder:
$ dotnet publish
$ docker build -t apiapplication .
$ docker run -p 8080:80 apiapplication
```

### API Request (use curl, Postman, whatever...)

```
# POST
$ curl http://localhost:8080/api/mission/launch/givensample
```

``` 
# POST
# Form parameters:      
# name - required - Name of the mission
# input - required - Input of the mission with the format given
$ curl http://localhost:8080/api/mission/launch

```

# Testing

The solution contains unit tests.
Test libraries used:
- [xUnit](https://xunit.net/)

To run the test you can use the following command:

```
$ dotnet test almost_crashing_robots.sln -c Release
```

# The Problem

The surface of Mars can be modelled by a rectangular grid around which robots are
able to move according to instructions provided from Earth. You are to write a
program that determines each sequence of robot positions and reports the final
position of the robot.

A robot position consists of a grid coordinate (a pair of integers: x-coordinate followed
by y-coordinate) and an orientation (N, S, E, W for north, south, east, and west). A
robot instruction is a string of the letters "L", "R", and "F" which represent,
respectively, the instructions:

* Left: the robot turns left 90 degrees and remains on the current grid point.
* Right: the robot turns right 90 degrees and remains on the current grid point.
* Forward: the robot moves forward one grid point in the direction of the current
orientation and maintains the same orientation.

The direction North corresponds to the direction from grid point (x, y) to grid point (x,
y+1).

There is also a possibility that additional command types may be required in the
future and provision should be made for this.

Since the grid is rectangular and bounded (...yes Mars is a strange planet), a robot
that moves "off" an edge of the grid is lost forever. However, lost robots leave a robot
"scent" that prohibits future robots from dropping off the world at the same grid point.
The scent is left at the last grid position the robot occupied before disappearing over
the edge. An instruction to move "off" the world from a grid point from which a robot
has been previously lost is simply ignored by the current robot.

## The input

The first line of input is the upper-right coordinates of the rectangular world, the
lower-left coordinates are assumed to be 0, 0.

The remaining input consists of a sequence of robot positions and instructions (two
lines per robot). A position consists of two integers specifying the initial coordinates
of the robot and an orientation (N, S, E, W), all separated by whitespace on one line.
A robot instruction is a string of the letters "L", "R", and "F" on one line.

Each robot is processed sequentially, i.e., finishes executing the robot instructions
before the next robot begins execution.

The maximum value for any coordinate is 50.

All instruction strings will be less than 100 characters in length.

### Sample input

```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFRFLFL
```

## The output

For each robot position/instruction in the input, the output should indicate the final
grid position and orientation of the robot. If a robot falls off the edge of the grid the
word "LOST" should be printed after the position and orientation.

### Sample Output

```
1 1 E
3 3 N LOST
4 2 N
```

# Possible improvements to be done

* Return back in time on going out of map
* Configurable max map size and commands length
* Better command result messages

# How to extend robot instructions

There is an abstract class `RobotMovementAction` you can use to further implement new robots instruction, as follows in this example:

```csharp
using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class MoveBackwardAction : RobotMovementAction
    {
        private static MoveBackwardAction Current { get; set; }

        private MoveBackwardAction() { }

        public static MoveBackwardAction Instance => Current ??= new MoveBackwardAction();

        public override void Execute(Map map, Robot robot)
        {
            var nextCoordinates = robot.GetBackwardCoordinates();
            var tileStatus = map.CheckTileStatus(nextCoordinates);
            
            HandleNextTileStatus(tileStatus, map, robot, nextCoordinates);
        }
    }
}
```

You also need to add to its enum type and extension class

```csharp
namespace Domain.Models
{
    public enum RobotCommandType
    {
        Forward = 'F',
        RotateLeft = 'L',
        RotateRight = 'R',
        Backward = 'B'
    }
}
```