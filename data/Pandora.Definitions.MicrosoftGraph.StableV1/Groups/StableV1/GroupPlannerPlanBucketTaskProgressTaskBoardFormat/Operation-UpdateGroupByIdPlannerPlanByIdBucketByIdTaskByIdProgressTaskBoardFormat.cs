// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPlannerPlanBucketTaskProgressTaskBoardFormat;

internal class UpdateGroupByIdPlannerPlanByIdBucketByIdTaskByIdProgressTaskBoardFormatOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PlannerProgressTaskBoardTaskFormatModel);
    public override ResourceID? ResourceId() => new GroupIdPlannerPlanIdBucketIdTaskId();
    public override Type? ResponseObject() => typeof(PlannerProgressTaskBoardTaskFormatModel);
    public override string? UriSuffix() => "/progressTaskBoardFormat";
}
