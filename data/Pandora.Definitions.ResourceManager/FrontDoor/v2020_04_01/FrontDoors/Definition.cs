using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

internal class Definition : ResourceDefinition
{
    public string Name => "FrontDoors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new EndpointsPurgeContentOperation(),
        new FrontendEndpointsDisableHttpsOperation(),
        new FrontendEndpointsEnableHttpsOperation(),
        new FrontendEndpointsGetOperation(),
        new FrontendEndpointsListByFrontDoorOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RulesEnginesCreateOrUpdateOperation(),
        new RulesEnginesDeleteOperation(),
        new RulesEnginesGetOperation(),
        new RulesEnginesListByFrontDoorOperation(),
        new ValidateCustomDomainOperation(),
    };
}
