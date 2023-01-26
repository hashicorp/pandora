using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.BastionHosts;

internal class GetActiveSessionsOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new BastionHostId();

    public override Type NestedItemType() => typeof(BastionActiveSessionModel);

    public override string? UriSuffix() => "/getActiveSessions";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
