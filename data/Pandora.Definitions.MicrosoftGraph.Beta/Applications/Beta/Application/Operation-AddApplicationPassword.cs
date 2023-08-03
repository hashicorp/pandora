using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.Application;

internal class AddApplicationPasswordOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AddApplicationPasswordRequestModel);
    public override ResourceID? ResourceId() => new ApplicationId();
    public override Type? ResponseObject() => typeof(PasswordCredentialModel);
    public override string? UriSuffix() => "/addPassword";
}
