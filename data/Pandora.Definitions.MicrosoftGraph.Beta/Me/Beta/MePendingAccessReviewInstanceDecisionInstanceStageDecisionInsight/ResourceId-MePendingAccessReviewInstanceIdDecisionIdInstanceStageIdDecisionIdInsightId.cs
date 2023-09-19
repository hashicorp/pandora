// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceDecisionInstanceStageDecisionInsight;

internal class MePendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionIdInsightId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/pendingAccessReviewInstances/{accessReviewInstanceId}/decisions/{accessReviewInstanceDecisionItemId}/instance/stages/{accessReviewStageId}/decisions/{accessReviewInstanceDecisionItemId1}/insights/{governanceInsightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPendingAccessReviewInstances", "pendingAccessReviewInstances"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceId"),
        ResourceIDSegment.Static("staticDecisions", "decisions"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceDecisionItemId"),
        ResourceIDSegment.Static("staticInstance", "instance"),
        ResourceIDSegment.Static("staticStages", "stages"),
        ResourceIDSegment.UserSpecified("accessReviewStageId"),
        ResourceIDSegment.Static("staticDecisions", "decisions"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceDecisionItemId1"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.UserSpecified("governanceInsightId")
    };
}
