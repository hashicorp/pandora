// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarViewByIdAttachmentOperation(),
        new DeleteMeCalendarViewByIdAttachmentByIdOperation(),
        new GetMeCalendarViewByIdAttachmentByIdOperation(),
        new GetMeCalendarViewByIdAttachmentCountOperation(),
        new ListMeCalendarViewByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdAttachmentCreateUploadSessionRequestModel)
    };
}
