using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ShareSubscription;

internal class Definition : ResourceDefinition
{
    public string Name => "ShareSubscription";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelSynchronizationOperation(),
        new ConsumerSourceDataSetsListByShareSubscriptionOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
        new ListSourceShareSynchronizationSettingsOperation(),
        new ListSynchronizationDetailsOperation(),
        new ListSynchronizationsOperation(),
        new SynchronizeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataSetTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(RecurrenceIntervalConstant),
        typeof(ShareKindConstant),
        typeof(ShareSubscriptionStatusConstant),
        typeof(SourceShareSynchronizationSettingKindConstant),
        typeof(StatusConstant),
        typeof(SynchronizationModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConsumerSourceDataSetModel),
        typeof(ConsumerSourceDataSetPropertiesModel),
        typeof(DataShareErrorInfoModel),
        typeof(OperationResponseModel),
        typeof(ScheduledSourceShareSynchronizationSettingPropertiesModel),
        typeof(ScheduledSourceSynchronizationSettingModel),
        typeof(ShareSubscriptionModel),
        typeof(ShareSubscriptionPropertiesModel),
        typeof(ShareSubscriptionSynchronizationModel),
        typeof(SourceShareSynchronizationSettingModel),
        typeof(SynchronizationDetailsModel),
        typeof(SynchronizeModel),
    };
}
