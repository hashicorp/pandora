// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamMember;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddGroupByIdTeamMemberOperation(),
        new CreateGroupByIdTeamMemberOperation(),
        new DeleteGroupByIdTeamMemberByIdOperation(),
        new GetGroupByIdTeamMemberByIdOperation(),
        new GetGroupByIdTeamMemberCountOperation(),
        new ListGroupByIdTeamMembersOperation(),
        new UpdateGroupByIdTeamMemberByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddGroupByIdTeamMemberRequestModel)
    };
}
