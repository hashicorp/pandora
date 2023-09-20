// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserTransitiveMemberOf;

internal class UserIdTransitiveMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/transitiveMemberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticTransitiveMemberOf", "transitiveMemberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
