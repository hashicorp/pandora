// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.Application;

internal class AddApplicationByIdKeyOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AddApplicationByIdKeyRequestModel);
    public override ResourceID? ResourceId() => new ApplicationId();
    public override Type? ResponseObject() => typeof(KeyCredentialModel);
    public override string? UriSuffix() => "/addKey";
}
