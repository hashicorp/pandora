// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTodoListTaskAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserTodoListTaskAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateUserByIdTodoListByIdTaskByIdAttachmentByIdValueOperation(),
        new CreateUserByIdTodoListByIdTaskByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdTodoListByIdTaskByIdAttachmentOperation(),
        new DeleteUserByIdTodoListByIdTaskByIdAttachmentByIdOperation(),
        new GetUserByIdTodoListByIdTaskByIdAttachmentByIdOperation(),
        new GetUserByIdTodoListByIdTaskByIdAttachmentByIdValueOperation(),
        new GetUserByIdTodoListByIdTaskByIdAttachmentCountOperation(),
        new ListUserByIdTodoListByIdTaskByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdTodoListByIdTaskByIdAttachmentCreateUploadSessionRequestModel)
    };
}
