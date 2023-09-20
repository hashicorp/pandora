// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserSecurityInformationProtection;

internal class UpdateUserByIdSecurityInformationProtectionOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(SecurityInformationProtectionModel);
    public override ResourceID? ResourceId() => new UserId();
    public override Type? ResponseObject() => typeof(SecurityInformationProtectionModel);
    public override string? UriSuffix() => "/security/informationProtection";
}
