// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserApprovalStep;

internal class UserIdApprovalIdStepId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/approvals/{approvalId}/steps/{approvalStepId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticApprovals", "approvals"),
        ResourceIDSegment.UserSpecified("approvalId"),
        ResourceIDSegment.Static("staticSteps", "steps"),
        ResourceIDSegment.UserSpecified("approvalStepId")
    };
}
