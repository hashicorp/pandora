// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceDecisionInstanceStageDecision;

internal class UserIdPendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/pendingAccessReviewInstances/{accessReviewInstanceId}/decisions/{accessReviewInstanceDecisionItemId}/instance/stages/{accessReviewStageId}/decisions/{accessReviewInstanceDecisionItemId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticPendingAccessReviewInstances", "pendingAccessReviewInstances"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceId"),
        ResourceIDSegment.Static("staticDecisions", "decisions"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceDecisionItemId"),
        ResourceIDSegment.Static("staticInstance", "instance"),
        ResourceIDSegment.Static("staticStages", "stages"),
        ResourceIDSegment.UserSpecified("accessReviewStageId"),
        ResourceIDSegment.Static("staticDecisions", "decisions"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceDecisionItemId1")
    };
}
