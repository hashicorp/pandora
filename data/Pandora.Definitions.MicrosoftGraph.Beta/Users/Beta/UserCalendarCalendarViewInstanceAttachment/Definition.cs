// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentsOperation(),
        new ListUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
