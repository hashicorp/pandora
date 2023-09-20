// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTodoListTaskAttachmentSessionContent;

internal class MeTodoListIdTaskIdAttachmentSessionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/todo/lists/{todoTaskListId}/tasks/{todoTaskId}/attachmentSessions/{attachmentSessionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticTodo", "todo"),
        ResourceIDSegment.Static("staticLists", "lists"),
        ResourceIDSegment.UserSpecified("todoTaskListId"),
        ResourceIDSegment.Static("staticTasks", "tasks"),
        ResourceIDSegment.UserSpecified("todoTaskId"),
        ResourceIDSegment.Static("staticAttachmentSessions", "attachmentSessions"),
        ResourceIDSegment.UserSpecified("attachmentSessionId")
    };
}
