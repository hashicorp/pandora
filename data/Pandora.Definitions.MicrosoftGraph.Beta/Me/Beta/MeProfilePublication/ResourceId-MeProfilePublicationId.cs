// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfilePublication;

internal class MeProfilePublicationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/publications/{itemPublicationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticPublications", "publications"),
        ResourceIDSegment.UserSpecified("itemPublicationId")
    };
}
