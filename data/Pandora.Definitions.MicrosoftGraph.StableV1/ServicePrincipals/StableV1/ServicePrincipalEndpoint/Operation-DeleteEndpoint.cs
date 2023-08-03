using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalEndpoint;

internal class DeleteEndpointOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };
    public override ResourceID? ResourceId() => new EndpointId();
    public override string? UriSuffix() => null;
}
