// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarViewInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarViewByIdInstanceByIdAttachmentOperation(),
        new DeleteMeCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarViewByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarViewByIdInstanceByIdAttachmentCountOperation(),
        new ListMeCalendarViewByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
