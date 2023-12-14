// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
