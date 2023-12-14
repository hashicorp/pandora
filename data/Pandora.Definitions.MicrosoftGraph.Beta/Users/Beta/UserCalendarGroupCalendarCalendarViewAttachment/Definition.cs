// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarCalendarViewAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarCalendarViewAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentOperation(),
        new DeleteUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdAttachmentCreateUploadSessionRequestModel)
    };
}
