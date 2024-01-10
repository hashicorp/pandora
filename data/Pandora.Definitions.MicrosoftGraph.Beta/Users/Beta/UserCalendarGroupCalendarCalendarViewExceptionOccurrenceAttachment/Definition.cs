// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarCalendarViewExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarCalendarViewExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
