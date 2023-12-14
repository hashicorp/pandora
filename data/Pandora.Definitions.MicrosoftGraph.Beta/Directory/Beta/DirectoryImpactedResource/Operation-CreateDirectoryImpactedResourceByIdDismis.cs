// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryImpactedResource;

internal class CreateDirectoryImpactedResourceByIdDismisOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateDirectoryImpactedResourceByIdDismisRequestModel);
    public override ResourceID? ResourceId() => new DirectoryImpactedResourceId();
    public override Type? ResponseObject() => typeof(ImpactedResourceModel);
    public override string? UriSuffix() => "/dismiss";
}
