using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckFrontDoorNameAvailability.Definition(),
        new CheckFrontDoorNameAvailabilityWithSubscription.Definition(),
        new FrontDoors.Definition(),
        new WebApplicationFirewallManagedRuleSets.Definition(),
        new WebApplicationFirewallPolicies.Definition(),
    };
}
