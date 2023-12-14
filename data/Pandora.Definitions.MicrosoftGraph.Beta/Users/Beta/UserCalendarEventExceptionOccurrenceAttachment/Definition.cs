// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
