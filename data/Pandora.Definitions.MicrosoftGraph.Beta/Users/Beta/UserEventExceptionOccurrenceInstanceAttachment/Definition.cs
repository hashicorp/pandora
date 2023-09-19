// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventExceptionOccurrenceInstanceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEventExceptionOccurrenceInstanceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentOperation(),
        new DeleteUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentByIdOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCountOperation(),
        new ListUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
