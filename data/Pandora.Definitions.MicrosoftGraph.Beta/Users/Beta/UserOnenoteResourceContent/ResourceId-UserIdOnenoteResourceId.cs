// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteResourceContent;

internal class UserIdOnenoteResourceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onenote/resources/{onenoteResourceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticResources", "resources"),
        ResourceIDSegment.UserSpecified("onenoteResourceId")
    };
}
