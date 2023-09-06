using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.Disks;

internal class Definition : ResourceDefinition
{
    public string Name => "Disks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GrantAccessOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RevokeAccessOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessLevelConstant),
        typeof(ArchitectureConstant),
        typeof(DataAccessAuthModeConstant),
        typeof(DiskCreateOptionConstant),
        typeof(DiskSecurityTypesConstant),
        typeof(DiskStateConstant),
        typeof(DiskStorageAccountTypesConstant),
        typeof(EncryptionTypeConstant),
        typeof(FileFormatConstant),
        typeof(HyperVGenerationConstant),
        typeof(NetworkAccessPolicyConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessUriModel),
        typeof(CreationDataModel),
        typeof(DiskModel),
        typeof(DiskPropertiesModel),
        typeof(DiskSecurityProfileModel),
        typeof(DiskSkuModel),
        typeof(DiskUpdateModel),
        typeof(DiskUpdatePropertiesModel),
        typeof(EncryptionModel),
        typeof(EncryptionSettingsCollectionModel),
        typeof(EncryptionSettingsElementModel),
        typeof(GrantAccessDataModel),
        typeof(ImageDiskReferenceModel),
        typeof(KeyVaultAndKeyReferenceModel),
        typeof(KeyVaultAndSecretReferenceModel),
        typeof(PropertyUpdatesInProgressModel),
        typeof(PurchasePlanModel),
        typeof(ShareInfoElementModel),
        typeof(SourceVaultModel),
        typeof(SupportedCapabilitiesModel),
    };
}
