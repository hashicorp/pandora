// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteGroupByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListGroupByIdEventByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
