using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ProductsByTag;

internal class ProductListByTagsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ServiceId();

    public override Type NestedItemType() => typeof(TagResourceContractModel);

    public override Type? OptionsObject() => typeof(ProductListByTagsOperation.ProductListByTagsOptions);

    public override string? UriSuffix() => "/productsByTags";

    internal class ProductListByTagsOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("includeNotTaggedProducts")]
        [Optional]
        public bool IncludeNotTaggedProducts { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
