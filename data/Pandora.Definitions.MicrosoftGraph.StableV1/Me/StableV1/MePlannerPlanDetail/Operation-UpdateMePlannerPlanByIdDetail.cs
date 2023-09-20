// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MePlannerPlanDetail;

internal class UpdateMePlannerPlanByIdDetailOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PlannerPlanDetailsModel);
    public override ResourceID? ResourceId() => new MePlannerPlanId();
    public override Type? ResponseObject() => typeof(PlannerPlanDetailsModel);
    public override string? UriSuffix() => "/details";
}
