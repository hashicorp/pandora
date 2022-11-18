using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.QueryKeys;

internal class ListBySearchServiceOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new SearchServiceId();

\t\tpublic override Type NestedItemType() => typeof(QueryKeyModel);

\t\tpublic override Type? OptionsObject() => typeof(ListBySearchServiceOperation.ListBySearchServiceOptions);

\t\tpublic override string? UriSuffix() => "/listQueryKeys";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class ListBySearchServiceOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
