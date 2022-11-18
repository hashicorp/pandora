using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Datastore;

internal class ListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(DatastoreResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/dataStores";

    internal class ListOptions
    {
        [QueryStringName("count")]
        [Optional]
        public int Count { get; set; }

        [QueryStringName("isDefault")]
        [Optional]
        public bool IsDefault { get; set; }

        [QueryStringName("names")]
        [Optional]
        public List<string> Names { get; set; }

        [QueryStringName("orderBy")]
        [Optional]
        public string OrderBy { get; set; }

        [QueryStringName("orderByAsc")]
        [Optional]
        public bool OrderByAsc { get; set; }

        [QueryStringName("searchText")]
        [Optional]
        public string SearchText { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
