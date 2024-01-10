// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionDataLossPreventionPolicy;

internal class UpdateGroupByIdSiteByIdInformationProtectionDataLossPreventionPolicyByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(DataLossPreventionPolicyModel);
    public override ResourceID? ResourceId() => new GroupIdSiteIdInformationProtectionDataLossPreventionPolicyId();
    public override Type? ResponseObject() => typeof(DataLossPreventionPolicyModel);
    public override string? UriSuffix() => null;
}
