// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupThread;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupThread";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdThreadByIdReplyOperation(),
        new CreateGroupByIdThreadOperation(),
        new DeleteGroupByIdThreadByIdOperation(),
        new GetGroupByIdThreadByIdOperation(),
        new GetGroupByIdThreadCountOperation(),
        new ListGroupByIdThreadsOperation(),
        new UpdateGroupByIdThreadByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdThreadByIdReplyRequestModel)
    };
}
