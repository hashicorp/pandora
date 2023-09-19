// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAppConsentRequestsForApprovalUserConsentRequestApprovalStep;

internal class UserIdAppConsentRequestsForApprovalIdUserConsentRequestId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/appConsentRequestsForApproval/{appConsentRequestId}/userConsentRequests/{userConsentRequestId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAppConsentRequestsForApproval", "appConsentRequestsForApproval"),
        ResourceIDSegment.UserSpecified("appConsentRequestId"),
        ResourceIDSegment.Static("staticUserConsentRequests", "userConsentRequests"),
        ResourceIDSegment.UserSpecified("userConsentRequestId")
    };
}
