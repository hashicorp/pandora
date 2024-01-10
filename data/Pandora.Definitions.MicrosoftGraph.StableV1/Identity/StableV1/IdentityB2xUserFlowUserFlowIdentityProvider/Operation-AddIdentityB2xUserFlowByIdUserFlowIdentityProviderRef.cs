// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowUserFlowIdentityProvider;

internal class AddIdentityB2xUserFlowByIdUserFlowIdentityProviderRefOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(ReferenceCreateModel);
    public override ResourceID? ResourceId() => new IdentityB2xUserFlowId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/userFlowIdentityProviders/$ref";
}
