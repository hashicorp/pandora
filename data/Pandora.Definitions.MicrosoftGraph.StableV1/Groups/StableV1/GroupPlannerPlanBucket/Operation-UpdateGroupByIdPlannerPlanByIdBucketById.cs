// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPlannerPlanBucket;

internal class UpdateGroupByIdPlannerPlanByIdBucketByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PlannerBucketModel);
    public override ResourceID? ResourceId() => new GroupIdPlannerPlanIdBucketId();
    public override Type? ResponseObject() => typeof(PlannerBucketModel);
    public override string? UriSuffix() => null;
}
