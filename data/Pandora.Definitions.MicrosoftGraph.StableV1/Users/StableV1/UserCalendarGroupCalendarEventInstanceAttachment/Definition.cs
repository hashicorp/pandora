// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarGroupCalendarEventInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarEventInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentOperation(),
        new DeleteUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
