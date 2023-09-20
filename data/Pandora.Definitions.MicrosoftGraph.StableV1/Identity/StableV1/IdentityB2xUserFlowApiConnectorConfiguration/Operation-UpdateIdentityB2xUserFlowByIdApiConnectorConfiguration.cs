// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowApiConnectorConfiguration;

internal class UpdateIdentityB2xUserFlowByIdApiConnectorConfigurationOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UserFlowApiConnectorConfigurationModel);
    public override ResourceID? ResourceId() => new IdentityB2xUserFlowId();
    public override Type? ResponseObject() => typeof(UserFlowApiConnectorConfigurationModel);
    public override string? UriSuffix() => "/apiConnectorConfiguration";
}
