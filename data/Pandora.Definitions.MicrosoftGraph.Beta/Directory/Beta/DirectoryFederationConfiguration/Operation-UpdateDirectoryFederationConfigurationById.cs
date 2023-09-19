// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryFederationConfiguration;

internal class UpdateDirectoryFederationConfigurationByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(IdentityProviderBaseModel);
    public override ResourceID? ResourceId() => new DirectoryFederationConfigurationId();
    public override Type? ResponseObject() => typeof(IdentityProviderBaseModel);
    public override string? UriSuffix() => null;
}
