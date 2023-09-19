// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteContentTypeColumn;

internal class CreateGroupByIdSiteByIdContentTypeByIdColumnOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ColumnDefinitionModel);
    public override ResourceID? ResourceId() => new GroupIdSiteIdContentTypeId();
    public override Type? ResponseObject() => typeof(ColumnDefinitionModel);
    public override string? UriSuffix() => "/columns";
}
