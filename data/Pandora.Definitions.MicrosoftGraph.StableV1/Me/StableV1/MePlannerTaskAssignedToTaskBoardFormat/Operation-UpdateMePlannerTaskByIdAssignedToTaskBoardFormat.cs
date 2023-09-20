// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MePlannerTaskAssignedToTaskBoardFormat;

internal class UpdateMePlannerTaskByIdAssignedToTaskBoardFormatOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PlannerAssignedToTaskBoardTaskFormatModel);
    public override ResourceID? ResourceId() => new MePlannerTaskId();
    public override Type? ResponseObject() => typeof(PlannerAssignedToTaskBoardTaskFormatModel);
    public override string? UriSuffix() => "/assignedToTaskBoardFormat";
}
