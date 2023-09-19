// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteListSubscription;

internal class CreateGroupByIdSiteByIdListByIdSubscriptionByIdReauthorizeOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => null;
    public override ResourceID? ResourceId() => new GroupIdSiteIdListIdSubscriptionId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/reauthorize";
}
