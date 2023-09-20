// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAppConsentRequestsForApprovalUserConsentRequestApprovalStep;

internal class MeAppConsentRequestsForApprovalIdUserConsentRequestIdApprovalStepId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/appConsentRequestsForApproval/{appConsentRequestId}/userConsentRequests/{userConsentRequestId}/approval/steps/{approvalStepId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAppConsentRequestsForApproval", "appConsentRequestsForApproval"),
        ResourceIDSegment.UserSpecified("appConsentRequestId"),
        ResourceIDSegment.Static("staticUserConsentRequests", "userConsentRequests"),
        ResourceIDSegment.UserSpecified("userConsentRequestId"),
        ResourceIDSegment.Static("staticApproval", "approval"),
        ResourceIDSegment.Static("staticSteps", "steps"),
        ResourceIDSegment.UserSpecified("approvalStepId")
    };
}
