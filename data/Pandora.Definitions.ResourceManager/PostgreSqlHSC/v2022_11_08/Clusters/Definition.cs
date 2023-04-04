using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CheckNameAvailabilityResourceTypeConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterModel),
        typeof(ClusterForUpdateModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterPropertiesForUpdateModel),
        typeof(MaintenanceWindowModel),
        typeof(NameAvailabilityModel),
        typeof(NameAvailabilityRequestModel),
        typeof(PrivateEndpointConnectionSimplePropertiesModel),
        typeof(PrivateEndpointPropertyModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ServerNameItemModel),
        typeof(SimplePrivateEndpointConnectionModel),
    };
}
