using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.BackupPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AbsoluteMarkerConstant),
        typeof(DataStoreTypesConstant),
        typeof(DayOfWeekConstant),
        typeof(MonthConstant),
        typeof(WeekNumberConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AbsoluteDeleteOptionModel),
        typeof(AdhocBasedTaggingCriteriaModel),
        typeof(AdhocBasedTriggerContextModel),
        typeof(AzureBackupParamsModel),
        typeof(AzureBackupRuleModel),
        typeof(AzureRetentionRuleModel),
        typeof(BackupCriteriaModel),
        typeof(BackupParametersModel),
        typeof(BackupPolicyModel),
        typeof(BackupScheduleModel),
        typeof(BaseBackupPolicyModel),
        typeof(BaseBackupPolicyResourceModel),
        typeof(BasePolicyRuleModel),
        typeof(CopyOnExpiryOptionModel),
        typeof(CopyOptionModel),
        typeof(CustomCopyOptionModel),
        typeof(DataStoreInfoBaseModel),
        typeof(DayModel),
        typeof(DeleteOptionModel),
        typeof(ImmediateCopyOptionModel),
        typeof(RetentionTagModel),
        typeof(ScheduleBasedBackupCriteriaModel),
        typeof(ScheduleBasedTriggerContextModel),
        typeof(SourceLifeCycleModel),
        typeof(TaggingCriteriaModel),
        typeof(TargetCopySettingModel),
        typeof(TriggerContextModel),
    };
}
