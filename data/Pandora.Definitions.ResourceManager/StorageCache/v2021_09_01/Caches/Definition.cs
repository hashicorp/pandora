using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;

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
        new StartOperation(),
        new StopOperation(),
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
        typeof(CacheUpgradeStatusModel),
        typeof(CacheUsernameDownloadSettingsModel),
        typeof(CacheUsernameDownloadSettingsCredentialsModel),
        typeof(ConditionModel),
        typeof(KeyVaultKeyReferenceModel),
        typeof(KeyVaultKeyReferenceSourceVaultModel),
        typeof(NfsAccessPolicyModel),
        typeof(NfsAccessRuleModel),
    };
}
