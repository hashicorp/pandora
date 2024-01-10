// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventInstanceExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEventInstanceExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdInstanceByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
