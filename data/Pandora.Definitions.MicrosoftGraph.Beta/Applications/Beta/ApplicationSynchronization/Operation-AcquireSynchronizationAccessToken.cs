using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronization;

internal class AcquireSynchronizationAccessTokenOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(AcquireSynchronizationAccessTokenRequestModel);
    public override ResourceID? ResourceId() => new ApplicationId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/synchronization/acquireAccessToken";
}
