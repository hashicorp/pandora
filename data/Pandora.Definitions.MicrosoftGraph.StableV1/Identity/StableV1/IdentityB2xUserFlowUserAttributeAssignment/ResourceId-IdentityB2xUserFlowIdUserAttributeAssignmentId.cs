// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowUserAttributeAssignment;

internal class IdentityB2xUserFlowIdUserAttributeAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/b2xUserFlows/{b2xIdentityUserFlowId}/userAttributeAssignments/{identityUserFlowAttributeAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticB2xUserFlows", "b2xUserFlows"),
        ResourceIDSegment.UserSpecified("b2xIdentityUserFlowId"),
        ResourceIDSegment.Static("staticUserAttributeAssignments", "userAttributeAssignments"),
        ResourceIDSegment.UserSpecified("identityUserFlowAttributeAssignmentId")
    };
}
