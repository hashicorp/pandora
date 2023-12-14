// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMemberOf;

internal class UserIdMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/memberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticMemberOf", "memberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
