// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThread;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupConversationThread";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdConversationByIdThreadByIdReplyOperation(),
        new CreateGroupByIdConversationByIdThreadOperation(),
        new DeleteGroupByIdConversationByIdThreadByIdOperation(),
        new GetGroupByIdConversationByIdThreadByIdOperation(),
        new GetGroupByIdConversationByIdThreadCountOperation(),
        new ListGroupByIdConversationByIdThreadsOperation(),
        new UpdateGroupByIdConversationByIdThreadByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdConversationByIdThreadByIdReplyRequestModel)
    };
}
