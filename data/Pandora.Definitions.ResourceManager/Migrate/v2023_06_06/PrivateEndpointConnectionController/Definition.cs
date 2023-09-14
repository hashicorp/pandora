using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.PrivateEndpointConnectionController;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnectionController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByMasterSiteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PrivateLinkServiceConnectionStateStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesV2Model),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ResourceIdModel),
    };
}
