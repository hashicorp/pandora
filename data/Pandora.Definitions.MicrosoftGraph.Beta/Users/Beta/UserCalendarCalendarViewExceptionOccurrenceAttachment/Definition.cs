// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
