// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskAttachment;

internal class MeOutlookTaskIdAttachmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/outlook/tasks/{outlookTaskId}/attachments/{attachmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOutlook", "outlook"),
        ResourceIDSegment.Static("staticTasks", "tasks"),
        ResourceIDSegment.UserSpecified("outlookTaskId"),
        ResourceIDSegment.Static("staticAttachments", "attachments"),
        ResourceIDSegment.UserSpecified("attachmentId")
    };
}
