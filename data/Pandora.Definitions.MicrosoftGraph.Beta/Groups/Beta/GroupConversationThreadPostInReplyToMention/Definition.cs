// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThreadPostInReplyToMention;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupConversationThreadPostInReplyToMention";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdConversationByIdThreadByIdPostByIdInReplyToMentionOperation(),
        new DeleteGroupByIdConversationByIdThreadByIdPostByIdInReplyToMentionByIdOperation(),
        new GetGroupByIdConversationByIdThreadByIdPostByIdInReplyToMentionByIdOperation(),
        new GetGroupByIdConversationByIdThreadByIdPostByIdInReplyToMentionCountOperation(),
        new ListGroupByIdConversationByIdThreadByIdPostByIdInReplyToMentionsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
