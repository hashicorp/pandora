// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTodoListTaskAttachmentSessionContent;

internal class UserIdTodoListIdTaskIdAttachmentSessionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/todo/lists/{todoTaskListId}/tasks/{todoTaskId}/attachmentSessions/{attachmentSessionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticTodo", "todo"),
        ResourceIDSegment.Static("staticLists", "lists"),
        ResourceIDSegment.UserSpecified("todoTaskListId"),
        ResourceIDSegment.Static("staticTasks", "tasks"),
        ResourceIDSegment.UserSpecified("todoTaskId"),
        ResourceIDSegment.Static("staticAttachmentSessions", "attachmentSessions"),
        ResourceIDSegment.UserSpecified("attachmentSessionId")
    };
}
