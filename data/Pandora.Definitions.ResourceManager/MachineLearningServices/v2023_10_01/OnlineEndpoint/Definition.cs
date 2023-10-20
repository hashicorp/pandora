using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.OnlineEndpoint;

internal class Definition : ResourceDefinition
{
    public string Name => "OnlineEndpoint";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetTokenOperation(),
        new ListOperation(),
        new ListKeysOperation(),
        new RegenerateKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EndpointAuthModeConstant),
        typeof(EndpointComputeTypeConstant),
        typeof(EndpointProvisioningStateConstant),
        typeof(KeyTypeConstant),
        typeof(ManagedServiceIdentityTypeConstant),
        typeof(OrderStringConstant),
        typeof(PublicNetworkAccessTypeConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EndpointAuthKeysModel),
        typeof(EndpointAuthTokenModel),
        typeof(OnlineEndpointModel),
        typeof(OnlineEndpointTrackedResourceModel),
        typeof(PartialManagedServiceIdentityModel),
        typeof(PartialMinimalTrackedResourceWithIdentityModel),
        typeof(RegenerateEndpointKeysRequestModel),
        typeof(SkuModel),
    };
}
