// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOutlookTaskGroup;

internal class UserIdOutlookTaskGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/outlook/taskGroups/{outlookTaskGroupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOutlook", "outlook"),
        ResourceIDSegment.Static("staticTaskGroups", "taskGroups"),
        ResourceIDSegment.UserSpecified("outlookTaskGroupId")
    };
}
