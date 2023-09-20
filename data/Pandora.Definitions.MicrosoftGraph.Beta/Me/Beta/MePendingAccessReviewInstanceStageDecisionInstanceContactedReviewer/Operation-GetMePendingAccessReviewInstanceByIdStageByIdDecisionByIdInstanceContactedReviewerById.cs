// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceStageDecisionInstanceContactedReviewer;

internal class GetMePendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceContactedReviewerByIdOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new MePendingAccessReviewInstanceIdStageIdDecisionIdInstanceContactedReviewerId();
    public override Type? ResponseObject() => typeof(AccessReviewReviewerModel);
    public override string? UriSuffix() => null;
}
