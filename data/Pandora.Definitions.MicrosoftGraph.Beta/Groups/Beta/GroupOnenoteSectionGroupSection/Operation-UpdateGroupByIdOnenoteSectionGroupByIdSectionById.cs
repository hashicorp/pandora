// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupOnenoteSectionGroupSection;

internal class UpdateGroupByIdOnenoteSectionGroupByIdSectionByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(OnenoteSectionModel);
    public override ResourceID? ResourceId() => new GroupIdOnenoteSectionGroupIdSectionId();
    public override Type? ResponseObject() => typeof(OnenoteSectionModel);
    public override string? UriSuffix() => null;
}
