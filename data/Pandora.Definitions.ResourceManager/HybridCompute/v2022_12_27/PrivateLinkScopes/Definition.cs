using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.PrivateLinkScopes;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLinkScopes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetValidationDetailsOperation(),
        new GetValidationDetailsForMachineOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PublicNetworkAccessTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionDetailModel),
        typeof(HybridComputePrivateLinkScopeModel),
        typeof(HybridComputePrivateLinkScopePropertiesModel),
        typeof(PrivateEndpointConnectionDataModelModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointPropertyModel),
        typeof(PrivateLinkScopeValidationDetailsModel),
        typeof(PrivateLinkServiceConnectionStatePropertyModel),
        typeof(TagsResourceModel),
    };
}
