# almost_crashing_robots
Robots walking on a grid based on instructiones given

# Possible improvements to be done
- Move backwards
- Return back in time on going out of grid
- Configurable max map size and commands length
- Add new input rules

# How to implement new robot instruction

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
            throw new NotImplementedException();
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