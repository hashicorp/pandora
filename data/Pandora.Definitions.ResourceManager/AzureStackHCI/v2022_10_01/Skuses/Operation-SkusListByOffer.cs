using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.Skuses;

internal class SkusListByOfferOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new OfferId();

\t\tpublic override Type NestedItemType() => typeof(SkuModel);

\t\tpublic override Type? OptionsObject() => typeof(SkusListByOfferOperation.SkusListByOfferOptions);

\t\tpublic override string? UriSuffix() => "/skus";

    internal class SkusListByOfferOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
