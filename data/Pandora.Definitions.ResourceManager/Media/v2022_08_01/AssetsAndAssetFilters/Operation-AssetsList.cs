using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AssetsAndAssetFilters;

internal class AssetsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "@odata.nextLink";

    public override ResourceID? ResourceId() => new MediaServiceId();

    public override Type NestedItemType() => typeof(AssetModel);

    public override Type? OptionsObject() => typeof(AssetsListOperation.AssetsListOptions);

    public override string? UriSuffix() => "/assets";

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
