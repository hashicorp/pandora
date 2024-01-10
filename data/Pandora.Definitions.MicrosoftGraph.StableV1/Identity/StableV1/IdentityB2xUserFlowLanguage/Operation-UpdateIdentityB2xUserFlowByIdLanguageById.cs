// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowLanguage;

internal class UpdateIdentityB2xUserFlowByIdLanguageByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UserFlowLanguageConfigurationModel);
    public override ResourceID? ResourceId() => new IdentityB2xUserFlowIdLanguageId();
    public override Type? ResponseObject() => typeof(UserFlowLanguageConfigurationModel);
    public override string? UriSuffix() => null;
}
