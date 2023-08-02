using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Domains;

internal class Definition : ResourceDefinition
{
    public string Name => "Domains";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListSharedAccessKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataResidencyBoundaryConstant),
        typeof(DomainProvisioningStateConstant),
        typeof(IPActionTypeConstant),
        typeof(InputSchemaConstant),
        typeof(InputSchemaMappingTypeConstant),
        typeof(PersistedConnectionStatusConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ResourceProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionStateModel),
        typeof(DomainModel),
        typeof(DomainPropertiesModel),
        typeof(DomainRegenerateKeyRequestModel),
        typeof(DomainSharedAccessKeysModel),
        typeof(DomainUpdateParameterPropertiesModel),
        typeof(DomainUpdateParametersModel),
        typeof(InboundIPRuleModel),
        typeof(InputSchemaMappingModel),
        typeof(JsonFieldModel),
        typeof(JsonFieldWithDefaultModel),
        typeof(JsonInputSchemaMappingModel),
        typeof(JsonInputSchemaMappingPropertiesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
    };
}
