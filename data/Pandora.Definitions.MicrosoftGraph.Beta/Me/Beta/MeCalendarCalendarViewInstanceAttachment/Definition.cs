// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarCalendarViewByIdInstanceByIdAttachmentOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentCountOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarCalendarViewByIdInstanceByIdAttachmentCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentsOperation(),
        new ListMeCalendarCalendarViewByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
