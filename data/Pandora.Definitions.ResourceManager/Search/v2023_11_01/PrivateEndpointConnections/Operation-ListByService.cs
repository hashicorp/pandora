using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2023_11_01.PrivateEndpointConnections;

internal class ListByServiceOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SearchServiceId();

    public override Type NestedItemType() => typeof(PrivateEndpointConnectionModel);

    public override Type? OptionsObject() => typeof(ListByServiceOperation.ListByServiceOptions);

    public override string? UriSuffix() => "/privateEndpointConnections";

    internal class ListByServiceOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
