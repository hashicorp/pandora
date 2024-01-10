// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMailFolderMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolderMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdMessageByIdCopyOperation(),
        new CreateMeMailFolderByIdMessageByIdCreateForwardOperation(),
        new CreateMeMailFolderByIdMessageByIdCreateReplyAllOperation(),
        new CreateMeMailFolderByIdMessageByIdCreateReplyOperation(),
        new CreateMeMailFolderByIdMessageByIdForwardOperation(),
        new CreateMeMailFolderByIdMessageByIdMoveOperation(),
        new CreateMeMailFolderByIdMessageByIdReplyAllOperation(),
        new CreateMeMailFolderByIdMessageByIdReplyOperation(),
        new CreateMeMailFolderByIdMessageByIdSendOperation(),
        new CreateMeMailFolderByIdMessageOperation(),
        new CreateUpdateMeMailFolderByIdMessageByIdValueOperation(),
        new DeleteMeMailFolderByIdMessageByIdOperation(),
        new GetMeMailFolderByIdMessageByIdOperation(),
        new GetMeMailFolderByIdMessageByIdValueOperation(),
        new GetMeMailFolderByIdMessageCountOperation(),
        new ListMeMailFolderByIdMessagesOperation(),
        new UpdateMeMailFolderByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeMailFolderByIdMessageByIdCopyRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdCreateForwardRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdCreateReplyAllRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdCreateReplyRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdForwardRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdMoveRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdReplyAllRequestModel),
        typeof(CreateMeMailFolderByIdMessageByIdReplyRequestModel)
    };
}
