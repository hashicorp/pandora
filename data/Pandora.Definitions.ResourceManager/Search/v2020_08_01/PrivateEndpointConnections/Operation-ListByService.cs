using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.PrivateEndpointConnections;

internal class ListByServiceOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SearchServiceId();

\t\tpublic override Type NestedItemType() => typeof(PrivateEndpointConnectionModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByServiceOperation.ListByServiceOptions);

\t\tpublic override string? UriSuffix() => "/privateEndpointConnections";

    internal class ListByServiceOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
