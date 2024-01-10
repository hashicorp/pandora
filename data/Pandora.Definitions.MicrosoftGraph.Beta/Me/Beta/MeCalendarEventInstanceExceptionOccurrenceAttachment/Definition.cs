// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
