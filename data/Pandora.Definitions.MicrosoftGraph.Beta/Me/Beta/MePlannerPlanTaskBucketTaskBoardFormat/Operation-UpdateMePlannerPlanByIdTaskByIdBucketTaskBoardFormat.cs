// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePlannerPlanTaskBucketTaskBoardFormat;

internal class UpdateMePlannerPlanByIdTaskByIdBucketTaskBoardFormatOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PlannerBucketTaskBoardTaskFormatModel);
    public override ResourceID? ResourceId() => new MePlannerPlanIdTaskId();
    public override Type? ResponseObject() => typeof(PlannerBucketTaskBoardTaskFormatModel);
    public override string? UriSuffix() => "/bucketTaskBoardFormat";
}
