// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenoteSectionPageContent;

internal class GetGroupByIdSiteByIdOnenoteSectionByIdPageByIdContentOperation : Operations.GetOperation
{
    public override string? ContentType() => "application/octet-stream";
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new GroupIdSiteIdOnenoteSectionIdPageId();
    public override Type? ResponseObject() => typeof(RawFile);
    public override string? UriSuffix() => "/content";
}
