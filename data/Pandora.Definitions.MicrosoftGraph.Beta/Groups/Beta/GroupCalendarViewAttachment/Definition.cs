// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdCalendarViewByIdAttachmentOperation(),
        new DeleteGroupByIdCalendarViewByIdAttachmentByIdOperation(),
        new GetGroupByIdCalendarViewByIdAttachmentByIdOperation(),
        new GetGroupByIdCalendarViewByIdAttachmentCountOperation(),
        new ListGroupByIdCalendarViewByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdAttachmentCreateUploadSessionRequestModel)
    };
}
