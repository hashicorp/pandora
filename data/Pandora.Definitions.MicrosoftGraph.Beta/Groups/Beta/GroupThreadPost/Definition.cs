// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupThreadPost;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupThreadPost";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdThreadByIdPostByIdForwardOperation(),
        new CreateGroupByIdThreadByIdPostByIdReplyOperation(),
        new GetGroupByIdThreadByIdPostByIdOperation(),
        new GetGroupByIdThreadByIdPostCountOperation(),
        new ListGroupByIdThreadByIdPostsOperation(),
        new UpdateGroupByIdThreadByIdPostByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdThreadByIdPostByIdForwardRequestModel),
        typeof(CreateGroupByIdThreadByIdPostByIdReplyRequestModel)
    };
}
