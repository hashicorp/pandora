// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarEventAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarByIdEventByIdAttachmentOperation(),
        new CreateUserByIdCalendarEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarEventByIdAttachmentOperation(),
        new DeleteUserByIdCalendarByIdEventByIdAttachmentByIdOperation(),
        new DeleteUserByIdCalendarEventByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdAttachmentCountOperation(),
        new GetUserByIdCalendarEventByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarEventByIdAttachmentCountOperation(),
        new ListUserByIdCalendarByIdEventByIdAttachmentsOperation(),
        new ListUserByIdCalendarEventByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateUserByIdCalendarEventByIdAttachmentCreateUploadSessionRequestModel)
    };
}
