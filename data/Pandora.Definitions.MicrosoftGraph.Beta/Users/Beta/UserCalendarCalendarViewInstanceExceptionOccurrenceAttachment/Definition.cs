// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation(),
        new ListUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
