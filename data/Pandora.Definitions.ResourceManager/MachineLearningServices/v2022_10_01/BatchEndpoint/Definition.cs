using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchEndpoint;

internal class Definition : ResourceDefinition
{
    public string Name => "BatchEndpoint";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EndpointAuthModeConstant),
        typeof(EndpointProvisioningStateConstant),
        typeof(ManagedServiceIdentityTypeConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BatchEndpointModel),
        typeof(BatchEndpointDefaultsModel),
        typeof(BatchEndpointTrackedResourceModel),
        typeof(EndpointAuthKeysModel),
        typeof(PartialManagedServiceIdentityModel),
        typeof(PartialMinimalTrackedResourceWithIdentityModel),
        typeof(SkuModel),
    };
}
