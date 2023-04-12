using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.Offers;

internal class OffersListByPublisherOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new PublisherId();

    public override Type NestedItemType() => typeof(OfferModel);

    public override Type? OptionsObject() => typeof(OffersListByPublisherOperation.OffersListByPublisherOptions);

    public override string? UriSuffix() => "/offers";

    internal class OffersListByPublisherOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
