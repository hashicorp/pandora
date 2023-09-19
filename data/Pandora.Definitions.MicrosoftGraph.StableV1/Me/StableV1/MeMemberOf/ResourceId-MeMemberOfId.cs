// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMemberOf;

internal class MeMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/memberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticMemberOf", "memberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
