// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExceptionOccurrenceInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExceptionOccurrenceInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation(),
        new ListMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
