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

internal class AssetsListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "@odata.nextLink";

\t\tpublic override ResourceID? ResourceId() => new MediaServiceId();

\t\tpublic override Type NestedItemType() => typeof(AssetModel);

\t\tpublic override Type? OptionsObject() => typeof(AssetsListOperation.AssetsListOptions);

\t\tpublic override string? UriSuffix() => "/assets";

    internal class AssetsListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
