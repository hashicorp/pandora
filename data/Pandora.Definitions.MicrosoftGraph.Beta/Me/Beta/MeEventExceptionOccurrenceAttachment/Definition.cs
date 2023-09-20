// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteMeEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListMeEventByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
