using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AssetsAndAssetFilters;

internal class AssetFiltersListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "@odata.nextLink";

    public override ResourceID? ResourceId() => new AssetId();

    public override Type NestedItemType() => typeof(AssetFilterModel);

    public override string? UriSuffix() => "/assetFilters";


}
