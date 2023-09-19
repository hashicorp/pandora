// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMailFolderChildFolderMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolderChildFolderMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdCopyOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdCreateForwardOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdCreateReplyAllOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdCreateReplyOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdForwardOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdMoveOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdReplyAllOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdReplyOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageByIdSendOperation(),
        new CreateMeMailFolderByIdChildFolderByIdMessageOperation(),
        new CreateUpdateMeMailFolderByIdChildFolderByIdMessageByIdValueOperation(),
        new DeleteMeMailFolderByIdChildFolderByIdMessageByIdOperation(),
        new GetMeMailFolderByIdChildFolderByIdMessageByIdOperation(),
        new GetMeMailFolderByIdChildFolderByIdMessageByIdValueOperation(),
        new GetMeMailFolderByIdChildFolderByIdMessageCountOperation(),
        new ListMeMailFolderByIdChildFolderByIdMessagesOperation(),
        new UpdateMeMailFolderByIdChildFolderByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdCopyRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdCreateForwardRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdCreateReplyAllRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdCreateReplyRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdForwardRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdMoveRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdReplyAllRequestModel),
        typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdReplyRequestModel)
    };
}
