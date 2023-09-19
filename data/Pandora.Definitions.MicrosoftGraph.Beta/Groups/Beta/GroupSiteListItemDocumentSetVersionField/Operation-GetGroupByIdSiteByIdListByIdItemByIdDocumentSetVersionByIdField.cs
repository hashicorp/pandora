// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListItemDocumentSetVersionField;

internal class GetGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionByIdFieldOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new GroupIdSiteIdListIdItemIdDocumentSetVersionId();
    public override Type? ResponseObject() => typeof(FieldValueSetModel);
    public override string? UriSuffix() => "/fields";
}
