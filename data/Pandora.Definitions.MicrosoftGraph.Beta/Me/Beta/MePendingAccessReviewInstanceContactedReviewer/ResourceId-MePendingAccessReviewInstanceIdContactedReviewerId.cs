// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceContactedReviewer;

internal class MePendingAccessReviewInstanceIdContactedReviewerId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/pendingAccessReviewInstances/{accessReviewInstanceId}/contactedReviewers/{accessReviewReviewerId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPendingAccessReviewInstances", "pendingAccessReviewInstances"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceId"),
        ResourceIDSegment.Static("staticContactedReviewers", "contactedReviewers"),
        ResourceIDSegment.UserSpecified("accessReviewReviewerId")
    };
}
