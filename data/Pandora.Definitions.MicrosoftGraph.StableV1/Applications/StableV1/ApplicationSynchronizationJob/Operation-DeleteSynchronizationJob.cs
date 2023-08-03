using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationJob;

internal class DeleteSynchronizationJobOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };
    public override ResourceID? ResourceId() => new SynchronizationJobId();
    public override string? UriSuffix() => null;
}
