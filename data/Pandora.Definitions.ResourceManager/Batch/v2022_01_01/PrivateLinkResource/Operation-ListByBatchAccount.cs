using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.PrivateLinkResource;

internal class ListByBatchAccountOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new BatchAccountId();

    public override Type NestedItemType() => typeof(PrivateLinkResourceModel);

    public override Type? OptionsObject() => typeof(ListByBatchAccountOperation.ListByBatchAccountOptions);

    public override string? UriSuffix() => "/privateLinkResources";

    internal class ListByBatchAccountOptions
    {
        [QueryStringName("maxresults")]
        [Optional]
        public int Maxresults { get; set; }
    }
}
