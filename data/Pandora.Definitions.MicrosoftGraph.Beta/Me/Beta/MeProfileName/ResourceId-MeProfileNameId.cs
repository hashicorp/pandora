// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileName;

internal class MeProfileNameId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/names/{personNameId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticNames", "names"),
        ResourceIDSegment.UserSpecified("personNameId")
    };
}
