// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListMeCalendarEventByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
