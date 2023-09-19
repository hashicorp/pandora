// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamTag;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamTag";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamTagOperation(),
        new DeleteGroupByIdTeamTagByIdOperation(),
        new GetGroupByIdTeamTagByIdOperation(),
        new GetGroupByIdTeamTagCountOperation(),
        new ListGroupByIdTeamTagsOperation(),
        new UpdateGroupByIdTeamTagByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
