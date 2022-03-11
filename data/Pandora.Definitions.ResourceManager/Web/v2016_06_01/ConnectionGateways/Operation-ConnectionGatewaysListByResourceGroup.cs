using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;

internal class ConnectionGatewaysListByResourceGroupOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type? ResponseObject() => typeof(ConnectionGatewayDefinitionCollectionModel);

    public override string? UriSuffix() => "/providers/Microsoft.Web/connectionGateways";


}
