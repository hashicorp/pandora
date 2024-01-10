// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventExceptionOccurrenceInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventExceptionOccurrenceInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new DeleteGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new ListGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
