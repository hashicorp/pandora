using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteLinks;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteLinks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExpressRouteLinkAdminStateConstant),
        typeof(ExpressRouteLinkConnectorTypeConstant),
        typeof(ExpressRouteLinkMacSecCipherConstant),
        typeof(ExpressRouteLinkMacSecSciStateConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteLinkModel),
        typeof(ExpressRouteLinkMacSecConfigModel),
        typeof(ExpressRouteLinkPropertiesFormatModel),
    };
}
