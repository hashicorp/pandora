// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventExceptionOccurrenceAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEventExceptionOccurrenceAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdAttachmentOperation(),
        new DeleteUserByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdAttachmentByIdOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdAttachmentCountOperation(),
        new ListUserByIdEventByIdExceptionOccurrenceByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdAttachmentCreateUploadSessionRequestModel)
    };
}
