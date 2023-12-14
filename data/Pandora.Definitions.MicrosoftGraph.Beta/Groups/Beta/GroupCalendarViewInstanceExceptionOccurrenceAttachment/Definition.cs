// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupCalendarViewInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
