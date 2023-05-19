using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImageVersions;

internal class Definition : ResourceDefinition
{
    public string Name => "GalleryImageVersions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByGalleryImageOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AggregatedReplicationStateConstant),
        typeof(ConfidentialVMEncryptionTypeConstant),
        typeof(EdgeZoneStorageAccountTypeConstant),
        typeof(GalleryExtendedLocationTypeConstant),
        typeof(GalleryProvisioningStateConstant),
        typeof(HostCachingConstant),
        typeof(PolicyViolationCategoryConstant),
        typeof(ReplicationModeConstant),
        typeof(ReplicationStateConstant),
        typeof(ReplicationStatusTypesConstant),
        typeof(StorageAccountTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataDiskImageEncryptionModel),
        typeof(EncryptionImagesModel),
        typeof(GalleryArtifactPublishingProfileBaseModel),
        typeof(GalleryArtifactVersionFullSourceModel),
        typeof(GalleryDataDiskImageModel),
        typeof(GalleryDiskImageModel),
        typeof(GalleryDiskImageSourceModel),
        typeof(GalleryExtendedLocationModel),
        typeof(GalleryImageVersionModel),
        typeof(GalleryImageVersionPropertiesModel),
        typeof(GalleryImageVersionSafetyProfileModel),
        typeof(GalleryImageVersionStorageProfileModel),
        typeof(GalleryImageVersionUpdateModel),
        typeof(GalleryTargetExtendedLocationModel),
        typeof(OSDiskImageEncryptionModel),
        typeof(OSDiskImageSecurityProfileModel),
        typeof(PolicyViolationModel),
        typeof(RegionalReplicationStatusModel),
        typeof(ReplicationStatusModel),
        typeof(TargetRegionModel),
    };
}
