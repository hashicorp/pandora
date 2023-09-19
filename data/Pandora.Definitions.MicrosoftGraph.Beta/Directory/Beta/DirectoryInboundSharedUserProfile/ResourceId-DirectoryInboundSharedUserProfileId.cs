// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryInboundSharedUserProfile;

internal class DirectoryInboundSharedUserProfileId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/inboundSharedUserProfiles/{inboundSharedUserProfileUserId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticInboundSharedUserProfiles", "inboundSharedUserProfiles"),
        ResourceIDSegment.UserSpecified("inboundSharedUserProfileUserId")
    };
}
