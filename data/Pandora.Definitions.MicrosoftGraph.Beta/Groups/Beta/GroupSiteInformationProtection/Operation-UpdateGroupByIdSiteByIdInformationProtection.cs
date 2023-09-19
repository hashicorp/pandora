// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtection;

internal class UpdateGroupByIdSiteByIdInformationProtectionOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(InformationProtectionModel);
    public override ResourceID? ResourceId() => new GroupIdSiteId();
    public override Type? ResponseObject() => typeof(InformationProtectionModel);
    public override string? UriSuffix() => "/informationProtection";
}
