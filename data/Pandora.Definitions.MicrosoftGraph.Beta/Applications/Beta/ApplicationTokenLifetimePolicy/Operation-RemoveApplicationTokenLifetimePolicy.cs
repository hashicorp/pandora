using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationTokenLifetimePolicy;

internal class RemoveApplicationTokenLifetimePolicyOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };
    public override ResourceID? ResourceId() => new TokenLifetimePolicyId();
    public override string? UriSuffix() => "/$ref";
}
