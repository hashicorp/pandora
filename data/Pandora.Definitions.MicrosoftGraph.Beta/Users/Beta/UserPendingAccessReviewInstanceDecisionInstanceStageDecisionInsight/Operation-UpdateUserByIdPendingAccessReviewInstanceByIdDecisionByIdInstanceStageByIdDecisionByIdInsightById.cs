// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceDecisionInstanceStageDecisionInsight;

internal class UpdateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdDecisionByIdInsightByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GovernanceInsightModel);
    public override ResourceID? ResourceId() => new UserIdPendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionIdInsightId();
    public override Type? ResponseObject() => typeof(GovernanceInsightModel);
    public override string? UriSuffix() => null;
}
