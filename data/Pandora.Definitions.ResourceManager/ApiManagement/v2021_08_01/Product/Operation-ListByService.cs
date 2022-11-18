using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Product;

internal class ListByServiceOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ServiceId();

\t\tpublic override Type NestedItemType() => typeof(ProductContractModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByServiceOperation.ListByServiceOptions);

\t\tpublic override string? UriSuffix() => "/products";

    internal class ListByServiceOptions
    {
        [QueryStringName("expandGroups")]
        [Optional]
        public bool ExpandGroups { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public string Tags { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
