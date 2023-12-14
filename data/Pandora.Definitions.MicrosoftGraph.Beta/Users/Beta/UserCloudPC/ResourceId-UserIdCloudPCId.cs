// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCloudPC;

internal class UserIdCloudPCId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/cloudPCs/{cloudPCId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticCloudPCs", "cloudPCs"),
        ResourceIDSegment.UserSpecified("cloudPCId")
    };
}
