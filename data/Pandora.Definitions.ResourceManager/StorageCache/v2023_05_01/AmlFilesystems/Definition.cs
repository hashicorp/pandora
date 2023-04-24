using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;

internal class Definition : ResourceDefinition
{
    public string Name => "AmlFilesystems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ArchiveOperation(),
        new CancelArchiveOperation(),
        new CheckAmlFSSubnetsOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetRequiredAmlFSSubnetsSizeOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AmlFilesystemHealthStateTypeConstant),
        typeof(AmlFilesystemIdentityTypeConstant),
        typeof(AmlFilesystemProvisioningStateTypeConstant),
        typeof(ArchiveStatusTypeConstant),
        typeof(MaintenanceDayOfWeekTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmlFilesystemModel),
        typeof(AmlFilesystemArchiveModel),
        typeof(AmlFilesystemArchiveInfoModel),
        typeof(AmlFilesystemArchiveStatusModel),
        typeof(AmlFilesystemClientInfoModel),
        typeof(AmlFilesystemContainerStorageInterfaceModel),
        typeof(AmlFilesystemEncryptionSettingsModel),
        typeof(AmlFilesystemHealthModel),
        typeof(AmlFilesystemHsmSettingsModel),
        typeof(AmlFilesystemIdentityModel),
        typeof(AmlFilesystemPropertiesModel),
        typeof(AmlFilesystemPropertiesHsmModel),
        typeof(AmlFilesystemPropertiesMaintenanceWindowModel),
        typeof(AmlFilesystemSubnetInfoModel),
        typeof(AmlFilesystemUpdateModel),
        typeof(AmlFilesystemUpdatePropertiesModel),
        typeof(AmlFilesystemUpdatePropertiesMaintenanceWindowModel),
        typeof(KeyVaultKeyReferenceModel),
        typeof(KeyVaultKeyReferenceSourceVaultModel),
        typeof(RequiredAmlFilesystemSubnetsSizeModel),
        typeof(RequiredAmlFilesystemSubnetsSizeInfoModel),
        typeof(SkuNameModel),
        typeof(UserAssignedIdentitiesPropertiesModel),
    };
}
