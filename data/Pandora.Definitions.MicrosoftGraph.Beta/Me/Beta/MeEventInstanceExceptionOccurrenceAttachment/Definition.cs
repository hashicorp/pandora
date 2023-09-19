// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
