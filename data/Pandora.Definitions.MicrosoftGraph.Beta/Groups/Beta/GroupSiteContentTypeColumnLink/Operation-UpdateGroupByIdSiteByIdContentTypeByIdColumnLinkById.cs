// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteContentTypeColumnLink;

internal class UpdateGroupByIdSiteByIdContentTypeByIdColumnLinkByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ColumnLinkModel);
    public override ResourceID? ResourceId() => new GroupIdSiteIdContentTypeIdColumnLinkId();
    public override Type? ResponseObject() => typeof(ColumnLinkModel);
    public override string? UriSuffix() => null;
}
