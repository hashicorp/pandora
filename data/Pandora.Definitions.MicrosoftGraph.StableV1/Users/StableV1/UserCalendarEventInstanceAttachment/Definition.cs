// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarEventInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdAttachmentOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdEventByIdInstanceByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarEventByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdAttachmentCountOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdEventByIdInstanceByIdAttachmentsOperation(),
        new ListUserByIdCalendarEventByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
