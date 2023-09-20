// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeScopedRoleMemberOf;

internal class MeScopedRoleMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/scopedRoleMemberOf/{scopedRoleMembershipId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticScopedRoleMemberOf", "scopedRoleMemberOf"),
        ResourceIDSegment.UserSpecified("scopedRoleMembershipId")
    };
}
