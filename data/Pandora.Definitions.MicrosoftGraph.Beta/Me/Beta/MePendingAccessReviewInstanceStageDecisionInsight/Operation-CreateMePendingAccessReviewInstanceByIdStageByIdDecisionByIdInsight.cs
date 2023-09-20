// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceStageDecisionInsight;

internal class CreateMePendingAccessReviewInstanceByIdStageByIdDecisionByIdInsightOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GovernanceInsightModel);
    public override ResourceID? ResourceId() => new MePendingAccessReviewInstanceIdStageIdDecisionId();
    public override Type? ResponseObject() => typeof(GovernanceInsightModel);
    public override string? UriSuffix() => "/insights";
}
