// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEventAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEventAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdAttachmentOperation(),
        new DeleteMeCalendarGroupByIdCalendarByIdEventByIdAttachmentByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdAttachmentByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdAttachmentCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarGroupByIdCalendarByIdEventByIdAttachmentCreateUploadSessionRequestModel)
    };
}
