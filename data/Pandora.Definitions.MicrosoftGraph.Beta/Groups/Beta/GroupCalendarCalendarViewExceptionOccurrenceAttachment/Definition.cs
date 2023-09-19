// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarCalendarViewExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarCalendarViewExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
