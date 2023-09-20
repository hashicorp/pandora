// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
