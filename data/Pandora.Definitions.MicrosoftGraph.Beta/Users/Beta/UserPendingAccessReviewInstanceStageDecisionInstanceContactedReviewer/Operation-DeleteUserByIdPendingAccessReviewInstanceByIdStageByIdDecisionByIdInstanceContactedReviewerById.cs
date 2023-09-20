// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStageDecisionInstanceContactedReviewer;

internal class DeleteUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceContactedReviewerByIdOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override ResourceID? ResourceId() => new UserIdPendingAccessReviewInstanceIdStageIdDecisionIdInstanceContactedReviewerId();
    public override string? UriSuffix() => null;
}
