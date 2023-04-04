using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.Snapshots;

internal class Definition : ResourceDefinition
{
    public string Name => "Snapshots";
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
        typeof(CopyCompletionErrorReasonConstant),
        typeof(DataAccessAuthModeConstant),
        typeof(DiskCreateOptionConstant),
        typeof(DiskSecurityTypesConstant),
        typeof(DiskStateConstant),
        typeof(EncryptionTypeConstant),
        typeof(HyperVGenerationConstant),
        typeof(NetworkAccessPolicyConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(SnapshotStorageAccountTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessUriModel),
        typeof(CopyCompletionErrorModel),
        typeof(CreationDataModel),
        typeof(DiskSecurityProfileModel),
        typeof(EncryptionModel),
        typeof(EncryptionSettingsCollectionModel),
        typeof(EncryptionSettingsElementModel),
        typeof(GrantAccessDataModel),
        typeof(ImageDiskReferenceModel),
        typeof(KeyVaultAndKeyReferenceModel),
        typeof(KeyVaultAndSecretReferenceModel),
        typeof(PurchasePlanModel),
        typeof(SnapshotModel),
        typeof(SnapshotPropertiesModel),
        typeof(SnapshotSkuModel),
        typeof(SnapshotUpdateModel),
        typeof(SnapshotUpdatePropertiesModel),
        typeof(SourceVaultModel),
        typeof(SupportedCapabilitiesModel),
    };
}
