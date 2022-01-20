using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.CheckFrontDoorNameAvailability;

internal class Definition : ResourceDefinition
{
    public string Name => "CheckFrontDoorNameAvailability";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckFrontDoorNameAvailabilityOperation(),
    };
}
