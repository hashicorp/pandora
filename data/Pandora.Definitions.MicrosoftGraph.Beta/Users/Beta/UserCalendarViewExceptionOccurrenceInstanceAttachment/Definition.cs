// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarViewExceptionOccurrenceInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarViewExceptionOccurrenceInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
