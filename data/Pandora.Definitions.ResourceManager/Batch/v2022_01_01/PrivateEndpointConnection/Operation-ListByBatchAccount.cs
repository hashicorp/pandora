using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.PrivateEndpointConnection;

internal class ListByBatchAccountOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new BatchAccountId();

\t\tpublic override Type NestedItemType() => typeof(PrivateEndpointConnectionModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByBatchAccountOperation.ListByBatchAccountOptions);

\t\tpublic override string? UriSuffix() => "/privateEndpointConnections";

    internal class ListByBatchAccountOptions
    {
        [QueryStringName("maxresults")]
        [Optional]
        public int Maxresults { get; set; }
    }
}
