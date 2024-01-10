// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceContactedReviewer;

internal class MePendingAccessReviewInstanceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/pendingAccessReviewInstances/{accessReviewInstanceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPendingAccessReviewInstances", "pendingAccessReviewInstances"),
        ResourceIDSegment.UserSpecified("accessReviewInstanceId")
    };
}
