// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarEventAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarByIdEventByIdAttachmentOperation(),
        new CreateMeCalendarEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarEventByIdAttachmentOperation(),
        new DeleteMeCalendarByIdEventByIdAttachmentByIdOperation(),
        new DeleteMeCalendarEventByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdAttachmentByIdOperation(),
        new GetMeCalendarByIdEventByIdAttachmentCountOperation(),
        new GetMeCalendarEventByIdAttachmentByIdOperation(),
        new GetMeCalendarEventByIdAttachmentCountOperation(),
        new ListMeCalendarByIdEventByIdAttachmentsOperation(),
        new ListMeCalendarEventByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarByIdEventByIdAttachmentCreateUploadSessionRequestModel),
        typeof(CreateMeCalendarEventByIdAttachmentCreateUploadSessionRequestModel)
    };
}
