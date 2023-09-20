// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryRecommendationImpactedResource;

internal class CreateDirectoryRecommendationByIdImpactedResourceOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ImpactedResourceModel);
    public override ResourceID? ResourceId() => new DirectoryRecommendationId();
    public override Type? ResponseObject() => typeof(ImpactedResourceModel);
    public override string? UriSuffix() => "/impactedResources";
}
