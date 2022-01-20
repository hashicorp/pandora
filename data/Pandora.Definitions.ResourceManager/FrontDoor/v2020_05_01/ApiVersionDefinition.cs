using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-05-01";
    public bool Preview => false;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckFrontDoorNameAvailability.Definition(),
        new CheckFrontDoorNameAvailabilityWithSubscription.Definition(),
        new FrontDoors.Definition(),
    };
}
