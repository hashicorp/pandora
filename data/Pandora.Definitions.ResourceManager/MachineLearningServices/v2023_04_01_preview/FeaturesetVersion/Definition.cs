using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.FeaturesetVersion;

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
        new ListMaterializationJobsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetProvisioningStateConstant),
        typeof(AutoDeleteConditionConstant),
        typeof(EmailNotificationEnableTypeConstant),
        typeof(FeaturestoreJobTypeConstant),
        typeof(JobStatusConstant),
        typeof(ListViewTypeConstant),
        typeof(MaterializationStoreTypeConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(TriggerTypeConstant),
        typeof(WebhookTypeConstant),
        typeof(WeekDayConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoDeleteSettingModel),
        typeof(AzureDevOpsWebhookModel),
        typeof(CronTriggerModel),
        typeof(FeatureWindowModel),
        typeof(FeaturesetJobModel),
        typeof(FeaturesetSpecificationModel),
        typeof(FeaturesetVersionModel),
        typeof(FeaturesetVersionBackfillRequestModel),
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
