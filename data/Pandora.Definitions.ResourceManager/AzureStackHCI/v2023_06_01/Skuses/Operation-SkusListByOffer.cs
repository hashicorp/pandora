using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.Skuses;

internal class SkusListByOfferOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new OfferId();

    public override Type NestedItemType() => typeof(SkuModel);

    public override Type? OptionsObject() => typeof(SkusListByOfferOperation.SkusListByOfferOptions);

    public override string? UriSuffix() => "/skus";

    internal class SkusListByOfferOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
