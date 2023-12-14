using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.FeaturesetVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "FeaturesetVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BackfillOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetProvisioningStateConstant),
        typeof(DataAvailabilityStatusConstant),
        typeof(EmailNotificationEnableTypeConstant),
        typeof(ListViewTypeConstant),
        typeof(MaterializationStoreTypeConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(TriggerTypeConstant),
        typeof(WebhookTypeConstant),
        typeof(WeekDayConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureDevOpsWebhookModel),
        typeof(CronTriggerModel),
        typeof(FeatureWindowModel),
        typeof(FeaturesetSpecificationModel),
        typeof(FeaturesetVersionModel),
        typeof(FeaturesetVersionBackfillRequestModel),
        typeof(FeaturesetVersionBackfillResponseModel),
        typeof(FeaturesetVersionResourceModel),
        typeof(MaterializationComputeResourceModel),
        typeof(MaterializationSettingsModel),
        typeof(NotificationSettingModel),
        typeof(RecurrenceScheduleModel),
        typeof(RecurrenceTriggerModel),
        typeof(TriggerBaseModel),
        typeof(WebhookModel),
    };
}
