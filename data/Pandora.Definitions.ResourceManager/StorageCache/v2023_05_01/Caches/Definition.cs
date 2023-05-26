using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.Caches;

internal class Definition : ResourceDefinition
{
    public string Name => "Caches";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DebugInfoOperation(),
        new DeleteOperation(),
        new FlushOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new PausePrimingJobOperation(),
        new ResumePrimingJobOperation(),
        new SpaceAllocationOperation(),
        new StartOperation(),
        new StartPrimingJobOperation(),
        new StopOperation(),
        new StopPrimingJobOperation(),
        new UpdateOperation(),
        new UpgradeFirmwareOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DomainJoinedTypeConstant),
        typeof(FirmwareStatusTypeConstant),
        typeof(HealthStateTypeConstant),
        typeof(NfsAccessRuleAccessConstant),
        typeof(NfsAccessRuleScopeConstant),
        typeof(PrimingJobStateConstant),
        typeof(ProvisioningStateTypeConstant),
        typeof(UsernameDownloadedTypeConstant),
        typeof(UsernameSourceConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CacheModel),
        typeof(CacheActiveDirectorySettingsModel),
        typeof(CacheActiveDirectorySettingsCredentialsModel),
        typeof(CacheDirectorySettingsModel),
        typeof(CacheEncryptionSettingsModel),
        typeof(CacheHealthModel),
        typeof(CacheNetworkSettingsModel),
        typeof(CachePropertiesModel),
        typeof(CacheSecuritySettingsModel),
        typeof(CacheSkuModel),
        typeof(CacheUpgradeSettingsModel),
        typeof(CacheUpgradeStatusModel),
        typeof(CacheUsernameDownloadSettingsModel),
        typeof(CacheUsernameDownloadSettingsCredentialsModel),
        typeof(ConditionModel),
        typeof(KeyVaultKeyReferenceModel),
        typeof(KeyVaultKeyReferenceSourceVaultModel),
        typeof(NfsAccessPolicyModel),
        typeof(NfsAccessRuleModel),
        typeof(PrimingJobModel),
        typeof(PrimingJobIdParameterModel),
        typeof(StorageTargetSpaceAllocationModel),
    };
}
