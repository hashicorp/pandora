// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMessageByIdCopyOperation(),
        new CreateMeMessageByIdCreateForwardOperation(),
        new CreateMeMessageByIdCreateReplyAllOperation(),
        new CreateMeMessageByIdCreateReplyOperation(),
        new CreateMeMessageByIdForwardOperation(),
        new CreateMeMessageByIdMoveOperation(),
        new CreateMeMessageByIdReplyAllOperation(),
        new CreateMeMessageByIdReplyOperation(),
        new CreateMeMessageByIdSendOperation(),
        new CreateMeMessageOperation(),
        new CreateUpdateMeMessageByIdValueOperation(),
        new DeleteMeMessageByIdOperation(),
        new GetMeMessageByIdOperation(),
        new GetMeMessageByIdValueOperation(),
        new GetMeMessageCountOperation(),
        new ListMeMessagesOperation(),
        new UpdateMeMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeMessageByIdCopyRequestModel),
        typeof(CreateMeMessageByIdCreateForwardRequestModel),
        typeof(CreateMeMessageByIdCreateReplyAllRequestModel),
        typeof(CreateMeMessageByIdCreateReplyRequestModel),
        typeof(CreateMeMessageByIdForwardRequestModel),
        typeof(CreateMeMessageByIdMoveRequestModel),
        typeof(CreateMeMessageByIdReplyAllRequestModel),
        typeof(CreateMeMessageByIdReplyRequestModel)
    };
}
