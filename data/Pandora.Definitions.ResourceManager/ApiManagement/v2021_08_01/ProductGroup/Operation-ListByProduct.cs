using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ProductGroup;

internal class ListByProductOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ProductId();

    public override Type NestedItemType() => typeof(GroupContractModel);

    public override Type? OptionsObject() => typeof(ListByProductOperation.ListByProductOptions);

    public override string? UriSuffix() => "/groups";

    internal class ListByProductOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
