// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupThreadPostInReplyToMention;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupThreadPostInReplyToMention";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdThreadByIdPostByIdInReplyToMentionOperation(),
        new DeleteGroupByIdThreadByIdPostByIdInReplyToMentionByIdOperation(),
        new GetGroupByIdThreadByIdPostByIdInReplyToMentionByIdOperation(),
        new GetGroupByIdThreadByIdPostByIdInReplyToMentionCountOperation(),
        new ListGroupByIdThreadByIdPostByIdInReplyToMentionsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
