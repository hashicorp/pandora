// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserSponsor;

internal class UserIdSponsorId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/sponsors/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticSponsors", "sponsors"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
