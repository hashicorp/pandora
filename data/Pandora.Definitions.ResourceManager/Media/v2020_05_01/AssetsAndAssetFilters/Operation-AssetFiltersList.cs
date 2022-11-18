using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.AssetsAndAssetFilters;

internal class AssetFiltersListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "@odata.nextLink";

\t\tpublic override ResourceID? ResourceId() => new AssetId();

\t\tpublic override Type NestedItemType() => typeof(AssetFilterModel);

\t\tpublic override string? UriSuffix() => "/assetFilters";


}
