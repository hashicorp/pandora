using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AssetsAndAssetFilters;

internal class Definition : ResourceDefinition
{
    public string Name => "AssetsAndAssetFilters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssetFiltersCreateOrUpdateOperation(),
        new AssetFiltersDeleteOperation(),
        new AssetFiltersGetOperation(),
        new AssetFiltersListOperation(),
        new AssetFiltersUpdateOperation(),
        new AssetsCreateOrUpdateOperation(),
        new AssetsDeleteOperation(),
        new AssetsGetOperation(),
        new AssetsGetEncryptionKeyOperation(),
        new AssetsListOperation(),
        new AssetsListContainerSasOperation(),
        new AssetsListStreamingLocatorsOperation(),
        new AssetsUpdateOperation(),
        new TracksCreateOrUpdateOperation(),
        new TracksDeleteOperation(),
        new TracksGetOperation(),
        new TracksListOperation(),
        new TracksUpdateOperation(),
        new TracksUpdateTrackDataOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetContainerPermissionConstant),
        typeof(AssetStorageEncryptionFormatConstant),
        typeof(FilterTrackPropertyCompareOperationConstant),
        typeof(FilterTrackPropertyTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(VisibilityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssetModel),
        typeof(AssetContainerSasModel),
        typeof(AssetFileEncryptionMetadataModel),
        typeof(AssetFilterModel),
        typeof(AssetPropertiesModel),
        typeof(AssetStreamingLocatorModel),
        typeof(AssetTrackModel),
        typeof(AssetTrackCollectionModel),
        typeof(AssetTrackPropertiesModel),
        typeof(AudioTrackModel),
        typeof(DashSettingsModel),
        typeof(FilterTrackPropertyConditionModel),
        typeof(FilterTrackSelectionModel),
        typeof(FirstQualityModel),
        typeof(HlsSettingsModel),
        typeof(ListContainerSasInputModel),
        typeof(ListStreamingLocatorsResponseModel),
        typeof(MediaFilterPropertiesModel),
        typeof(PresentationTimeRangeModel),
        typeof(StorageEncryptedAssetDecryptionDataModel),
        typeof(TextTrackModel),
        typeof(TrackBaseModel),
        typeof(VideoTrackModel),
    };
}
