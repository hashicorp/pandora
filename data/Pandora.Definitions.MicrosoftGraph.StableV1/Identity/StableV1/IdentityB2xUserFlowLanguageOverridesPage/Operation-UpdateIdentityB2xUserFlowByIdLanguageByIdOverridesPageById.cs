// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowLanguageOverridesPage;

internal class UpdateIdentityB2xUserFlowByIdLanguageByIdOverridesPageByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UserFlowLanguagePageModel);
    public override ResourceID? ResourceId() => new IdentityB2xUserFlowIdLanguageIdOverridesPageId();
    public override Type? ResponseObject() => typeof(UserFlowLanguagePageModel);
    public override string? UriSuffix() => null;
}
