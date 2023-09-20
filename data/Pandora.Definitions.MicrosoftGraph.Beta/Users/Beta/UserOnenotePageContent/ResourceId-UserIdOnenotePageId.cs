// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenotePageContent;

internal class UserIdOnenotePageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onenote/pages/{onenotePageId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnenote", "onenote"),
        ResourceIDSegment.Static("staticPages", "pages"),
        ResourceIDSegment.UserSpecified("onenotePageId")
    };
}
