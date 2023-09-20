// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolderMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateUserByIdMailFolderByIdMessageByIdValueOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdCopyOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdCreateForwardOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdCreateReplyAllOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdCreateReplyOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdForwardOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdMarkAsJunkOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdMarkAsNotJunkOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdMoveOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdReplyAllOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdReplyOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdSendOperation(),
        new CreateUserByIdMailFolderByIdMessageByIdUnsubscribeOperation(),
        new CreateUserByIdMailFolderByIdMessageOperation(),
        new DeleteUserByIdMailFolderByIdMessageByIdOperation(),
        new GetUserByIdMailFolderByIdMessageByIdOperation(),
        new GetUserByIdMailFolderByIdMessageByIdValueOperation(),
        new GetUserByIdMailFolderByIdMessageCountOperation(),
        new ListUserByIdMailFolderByIdMessagesOperation(),
        new UpdateUserByIdMailFolderByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdMailFolderByIdMessageByIdCopyRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdCreateForwardRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdCreateReplyAllRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdCreateReplyRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdForwardRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdMarkAsJunkRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdMarkAsNotJunkRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdMoveRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdReplyAllRequestModel),
        typeof(CreateUserByIdMailFolderByIdMessageByIdReplyRequestModel)
    };
}
