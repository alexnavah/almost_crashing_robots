# almost_crashing_robots
Robots walking on a grid based on instructiones given

# Possible improvements to be done
- Move backwards
- Return back in time on going out of grid
- Configurable max map size and commands length
- Add new input rules
- Avoid robot move validations saving already explored tiles
- Validation of robot commands input 'FRFRFRF'

# How to extend robot instructions

There is an interface `IRobotAction` you can use to further implement new robots instruction, as follows in this example:

```csharp
using Domain.Models.Interfaces;
using System;

namespace Domain.Models
{
    public class MoveBackwardAction : IRobotAction
    {
        public void Execute()
        {
            var nextCoordinates = robot.GetBackwardCoordinates();
            var tileStatus = grid.CheckTileStatus(nextCoordinates);

            switch (tileStatus)
            {
                case TileStatusType.Ignore:
                    break;
                case TileStatusType.Lost:
                    robot.FlagAsLost();
                    grid.AddLostRobotTile(nextCoordinates);
                    break;
                case TileStatusType.Move:
                    robot.MoveToCoordinates(nextCoordinates);
                    break;
            }
        }
    }
}
```

# Tests

The solution contains unit tests.
Test libraries used:
- [xUnit](https://xunit.net/)

To run the test you can use the following command:

```
$ dotnet test almost_crashing_robots.sln -c Release
```