// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAppConsentRequestsForApprovalUserConsentRequest;

internal class MeAppConsentRequestsForApprovalIdUserConsentRequestId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/appConsentRequestsForApproval/{appConsentRequestId}/userConsentRequests/{userConsentRequestId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAppConsentRequestsForApproval", "appConsentRequestsForApproval"),
        ResourceIDSegment.UserSpecified("appConsentRequestId"),
        ResourceIDSegment.Static("staticUserConsentRequests", "userConsentRequests"),
        ResourceIDSegment.UserSpecified("userConsentRequestId")
    };
}
