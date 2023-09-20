// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceDecisionInstanceStage;

internal class MePendingAccessReviewInstanceIdDecisionIdInstanceStageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/pendingAccessReviewInstances/{accessReviewInstanceId}/decisions/{accessReviewInstanceDecisionItemId}/instance/stages/{accessReviewStageId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPendingAccessReviewInstances", "pendingAccessReviewInstances"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceId"),
        ResourceIDSegment.Static("staticDecisions", "decisions"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceDecisionItemId"),
        ResourceIDSegment.Static("staticInstance", "instance"),
        ResourceIDSegment.Static("staticStages", "stages"),
        ResourceIDSegment.UserSpecified("accessReviewStageId")
    };
}
