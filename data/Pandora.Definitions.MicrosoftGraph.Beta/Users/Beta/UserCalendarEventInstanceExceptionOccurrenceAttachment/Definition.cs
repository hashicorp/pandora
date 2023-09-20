// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
