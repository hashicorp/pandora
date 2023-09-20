// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserApproval;

internal class UserIdApprovalId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/approvals/{approvalId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticApprovals", "approvals"),
        ResourceIDSegment.UserSpecified("approvalId")
    };
}
