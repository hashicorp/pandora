using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.AssetsAndAssetFilters;

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
    };
}
