// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MePeople;

internal class MePeopleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/people/{personId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticPeople", "people"),
        ResourceIDSegment.UserSpecified("personId")
    };
}
