using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupVaults;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupVaults";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetInResourceGroupOperation(),
        new GetInSubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertsStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(ResourceMoveStateConstant),
        typeof(StorageSettingStoreTypesConstant),
        typeof(StorageSettingTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureMonitorAlertSettingsModel),
        typeof(BackupVaultModel),
        typeof(BackupVaultResourceModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(DppIdentityDetailsModel),
        typeof(MonitoringSettingsModel),
        typeof(PatchBackupVaultInputModel),
        typeof(PatchResourceRequestInputModel),
        typeof(ResourceMoveDetailsModel),
        typeof(StorageSettingModel),
    };
}
