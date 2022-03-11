using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectionGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConnectionGatewayInstallationsGetOperation(),
        new ConnectionGatewayInstallationsListOperation(),
        new ConnectionGatewaysCreateOrUpdateOperation(),
        new ConnectionGatewaysDeleteOperation(),
        new ConnectionGatewaysGetOperation(),
        new ConnectionGatewaysListOperation(),
        new ConnectionGatewaysListByResourceGroupOperation(),
        new ConnectionGatewaysUpdateOperation(),
    };
}
