// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenoteResourceContent;

internal class CreateUpdateGroupByIdSiteByIdOnenoteResourceByIdContentOperation : Operations.PutOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(RawFile);
    public override ResourceID? ResourceId() => new GroupIdSiteIdOnenoteResourceId();
    public override Type? ResponseObject() => typeof(OnenoteResourceModel);
    public override string? UriSuffix() => "/content";
}
