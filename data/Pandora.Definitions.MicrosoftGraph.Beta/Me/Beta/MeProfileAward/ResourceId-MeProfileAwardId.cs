// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileAward;

internal class MeProfileAwardId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/awards/{personAwardId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticAwards", "awards"),
        ResourceIDSegment.UserSpecified("personAwardId")
    };
}
