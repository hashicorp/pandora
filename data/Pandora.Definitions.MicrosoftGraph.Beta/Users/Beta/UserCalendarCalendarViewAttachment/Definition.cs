// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdAttachmentOperation(),
        new CreateUserByIdCalendarCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdAttachmentCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdAttachmentsOperation(),
        new ListUserByIdCalendarCalendarViewByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdAttachmentCreateUploadSessionRequestModel)
    };
}
