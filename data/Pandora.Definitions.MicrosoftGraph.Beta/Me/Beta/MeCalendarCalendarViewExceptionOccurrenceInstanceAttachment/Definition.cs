// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrenceInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExceptionOccurrenceInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation(),
        new ListMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
