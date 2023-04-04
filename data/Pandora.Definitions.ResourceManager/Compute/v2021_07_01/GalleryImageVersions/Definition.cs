using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryImageVersions;

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
        typeof(HostCachingConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReplicationModeConstant),
        typeof(ReplicationStateConstant),
        typeof(ReplicationStatusTypesConstant),
        typeof(StorageAccountTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataDiskImageEncryptionModel),
        typeof(DiskImageEncryptionModel),
        typeof(EncryptionImagesModel),
        typeof(GalleryArtifactPublishingProfileBaseModel),
        typeof(GalleryArtifactVersionSourceModel),
        typeof(GalleryDataDiskImageModel),
        typeof(GalleryDiskImageModel),
        typeof(GalleryImageVersionModel),
        typeof(GalleryImageVersionPropertiesModel),
        typeof(GalleryImageVersionStorageProfileModel),
        typeof(GalleryImageVersionUpdateModel),
        typeof(RegionalReplicationStatusModel),
        typeof(ReplicationStatusModel),
        typeof(TargetRegionModel),
    };
}
