// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamOperation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamOperationOperation(),
        new DeleteGroupByIdTeamOperationByIdOperation(),
        new GetGroupByIdTeamOperationByIdOperation(),
        new GetGroupByIdTeamOperationCountOperation(),
        new ListGroupByIdTeamOperationsOperation(),
        new UpdateGroupByIdTeamOperationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
