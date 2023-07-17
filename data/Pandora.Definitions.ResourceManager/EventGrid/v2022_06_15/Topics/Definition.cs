using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Topics;

internal class Definition : ResourceDefinition
{
    public string Name => "Topics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExtensionTopicsGetOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListEventTypesOperation(),
        new ListSharedAccessKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataResidencyBoundaryConstant),
        typeof(IPActionTypeConstant),
        typeof(InputSchemaConstant),
        typeof(InputSchemaMappingTypeConstant),
        typeof(PersistedConnectionStatusConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ResourceProvisioningStateConstant),
        typeof(TopicProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionStateModel),
        typeof(EventTypeModel),
        typeof(EventTypePropertiesModel),
        typeof(EventTypesListResultModel),
        typeof(ExtensionTopicModel),
        typeof(ExtensionTopicPropertiesModel),
        typeof(InboundIPRuleModel),
        typeof(InputSchemaMappingModel),
        typeof(JsonFieldModel),
        typeof(JsonFieldWithDefaultModel),
        typeof(JsonInputSchemaMappingModel),
        typeof(JsonInputSchemaMappingPropertiesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(TopicModel),
        typeof(TopicPropertiesModel),
        typeof(TopicRegenerateKeyRequestModel),
        typeof(TopicSharedAccessKeysModel),
        typeof(TopicUpdateParameterPropertiesModel),
        typeof(TopicUpdateParametersModel),
    };
}
