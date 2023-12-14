// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDrive;

internal class UserIdDriveId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/drives/{driveId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticDrives", "drives"),
        ResourceIDSegment.UserSpecified("driveId")
    };
}
