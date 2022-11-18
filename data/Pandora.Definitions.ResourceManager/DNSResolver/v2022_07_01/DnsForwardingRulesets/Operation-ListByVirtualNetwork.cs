using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.DnsForwardingRulesets;

internal class ListByVirtualNetworkOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new VirtualNetworkId();

\t\tpublic override Type NestedItemType() => typeof(VirtualNetworkDnsForwardingRulesetModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByVirtualNetworkOperation.ListByVirtualNetworkOptions);

\t\tpublic override string? UriSuffix() => "/listDnsForwardingRulesets";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class ListByVirtualNetworkOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
