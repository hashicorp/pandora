// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserMailFolderChildFolderMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderChildFolderMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateUserByIdMailFolderByIdChildFolderByIdMessageByIdValueOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCopyOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateForwardOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateReplyAllOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateReplyOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdForwardOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdMoveOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdReplyAllOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdReplyOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdSendOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageOperation(),
        new DeleteUserByIdMailFolderByIdChildFolderByIdMessageByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdValueOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageCountOperation(),
        new ListUserByIdMailFolderByIdChildFolderByIdMessagesOperation(),
        new UpdateUserByIdMailFolderByIdChildFolderByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCopyRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateForwardRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateReplyAllRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateReplyRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdForwardRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdMoveRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdReplyAllRequestModel),
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdReplyRequestModel)
    };
}
