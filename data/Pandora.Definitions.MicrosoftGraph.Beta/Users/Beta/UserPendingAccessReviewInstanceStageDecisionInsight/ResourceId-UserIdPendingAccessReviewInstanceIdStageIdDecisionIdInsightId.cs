// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStageDecisionInsight;

internal class UserIdPendingAccessReviewInstanceIdStageIdDecisionIdInsightId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/pendingAccessReviewInstances/{accessReviewInstanceId}/stages/{accessReviewStageId}/decisions/{accessReviewInstanceDecisionItemId}/insights/{governanceInsightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticPendingAccessReviewInstances", "pendingAccessReviewInstances"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceId"),
        ResourceIDSegment.Static("staticStages", "stages"),
        ResourceIDSegment.UserSpecified("accessReviewStageId"),
        ResourceIDSegment.Static("staticDecisions", "decisions"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceDecisionItemId"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.UserSpecified("governanceInsightId")
    };
}
