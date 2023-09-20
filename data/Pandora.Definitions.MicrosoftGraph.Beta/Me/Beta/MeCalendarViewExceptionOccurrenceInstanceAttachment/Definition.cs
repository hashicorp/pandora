// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewExceptionOccurrenceInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewExceptionOccurrenceInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new DeleteMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new ListMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
