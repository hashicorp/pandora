using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationAccounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListCallbackUrlOperation(),
        new ListKeyVaultKeysOperation(),
        new LogTrackingEventsOperation(),
        new RegenerateAccessKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EventLevelConstant),
        typeof(IntegrationAccountSkuNameConstant),
        typeof(KeyTypeConstant),
        typeof(TrackEventsOperationOptionsConstant),
        typeof(TrackingRecordTypeConstant),
        typeof(WorkflowStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CallbackUrlModel),
        typeof(GetCallbackUrlParametersModel),
        typeof(IntegrationAccountModel),
        typeof(IntegrationAccountPropertiesModel),
        typeof(IntegrationAccountSkuModel),
        typeof(KeyVaultKeyModel),
        typeof(KeyVaultKeyAttributesModel),
        typeof(KeyVaultKeyCollectionModel),
        typeof(KeyVaultReferenceModel),
        typeof(ListKeyVaultKeysDefinitionModel),
        typeof(RegenerateActionParameterModel),
        typeof(ResourceReferenceModel),
        typeof(TrackingEventModel),
        typeof(TrackingEventErrorInfoModel),
        typeof(TrackingEventsDefinitionModel),
    };
}
