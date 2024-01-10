// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListActivity;

internal class CreateGroupByIdSiteByIdListByIdActivityOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ItemActivityOLDModel);
    public override ResourceID? ResourceId() => new GroupIdSiteIdListId();
    public override Type? ResponseObject() => typeof(ItemActivityOLDModel);
    public override string? UriSuffix() => "/activities";
}
