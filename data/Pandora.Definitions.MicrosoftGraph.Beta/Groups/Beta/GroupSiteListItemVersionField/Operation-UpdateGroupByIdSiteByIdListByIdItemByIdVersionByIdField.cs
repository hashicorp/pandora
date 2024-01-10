// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListItemVersionField;

internal class UpdateGroupByIdSiteByIdListByIdItemByIdVersionByIdFieldOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(FieldValueSetModel);
    public override ResourceID? ResourceId() => new GroupIdSiteIdListIdItemIdVersionId();
    public override Type? ResponseObject() => typeof(FieldValueSetModel);
    public override string? UriSuffix() => "/fields";
}
