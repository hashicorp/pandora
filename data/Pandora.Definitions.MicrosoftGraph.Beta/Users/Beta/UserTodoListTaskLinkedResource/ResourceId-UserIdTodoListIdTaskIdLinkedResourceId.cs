// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTodoListTaskLinkedResource;

internal class UserIdTodoListIdTaskIdLinkedResourceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/todo/lists/{todoTaskListId}/tasks/{todoTaskId}/linkedResources/{linkedResourceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticTodo", "todo"),
        ResourceIDSegment.Static("staticLists", "lists"),
        ResourceIDSegment.UserSpecified("todoTaskListId"),
        ResourceIDSegment.Static("staticTasks", "tasks"),
        ResourceIDSegment.UserSpecified("todoTaskId"),
        ResourceIDSegment.Static("staticLinkedResources", "linkedResources"),
        ResourceIDSegment.UserSpecified("linkedResourceId")
    };
}
