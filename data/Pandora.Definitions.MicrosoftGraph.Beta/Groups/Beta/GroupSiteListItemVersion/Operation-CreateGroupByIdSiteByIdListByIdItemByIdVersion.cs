// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListItemVersion;

internal class CreateGroupByIdSiteByIdListByIdItemByIdVersionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ListItemVersionModel);
    public override ResourceID? ResourceId() => new GroupIdSiteIdListIdItemId();
    public override Type? ResponseObject() => typeof(ListItemVersionModel);
    public override string? UriSuffix() => "/versions";
}
