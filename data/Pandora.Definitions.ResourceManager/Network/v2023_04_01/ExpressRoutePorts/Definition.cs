using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.ExpressRoutePorts;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRoutePorts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GenerateLOAOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExpressRouteLinkAdminStateConstant),
        typeof(ExpressRouteLinkConnectorTypeConstant),
        typeof(ExpressRouteLinkMacSecCipherConstant),
        typeof(ExpressRouteLinkMacSecSciStateConstant),
        typeof(ExpressRoutePortsBillingTypeConstant),
        typeof(ExpressRoutePortsEncapsulationConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteLinkModel),
        typeof(ExpressRouteLinkMacSecConfigModel),
        typeof(ExpressRouteLinkPropertiesFormatModel),
        typeof(ExpressRoutePortModel),
        typeof(ExpressRoutePortPropertiesFormatModel),
        typeof(GenerateExpressRoutePortsLOARequestModel),
        typeof(GenerateExpressRoutePortsLOAResultModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
