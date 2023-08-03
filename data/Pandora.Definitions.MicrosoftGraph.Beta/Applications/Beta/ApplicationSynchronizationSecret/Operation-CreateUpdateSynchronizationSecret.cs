using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronizationSecret;

internal class CreateUpdateSynchronizationSecretOperation : Operations.PutOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(SynchronizationSecretKeyStringValuePairModel);
    public override ResourceID? ResourceId() => new ApplicationId();
    public override Type? ResponseObject() => typeof(SynchronizationSecretKeyStringValuePairModel);
    public override string? UriSuffix() => "/synchronization/secrets";
}
