// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
