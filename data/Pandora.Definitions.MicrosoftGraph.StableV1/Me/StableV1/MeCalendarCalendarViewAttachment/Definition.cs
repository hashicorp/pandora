// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarCalendarViewAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdCalendarViewByIdAttachmentOperation(),
        new CreateMeCalendarCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarCalendarViewByIdAttachmentOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdAttachmentByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdAttachmentCountOperation(),
        new GetMeCalendarCalendarViewByIdAttachmentByIdOperation(),
        new GetMeCalendarCalendarViewByIdAttachmentCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdAttachmentsOperation(),
        new ListMeCalendarCalendarViewByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdCalendarViewByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarCalendarViewByIdAttachmentCreateUploadSessionRequestModel)
    };
}
