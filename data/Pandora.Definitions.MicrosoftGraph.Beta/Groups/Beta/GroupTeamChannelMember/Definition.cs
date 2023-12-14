// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamChannelMember;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamChannelMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddGroupByIdTeamChannelByIdMemberOperation(),
        new CreateGroupByIdTeamChannelByIdMemberOperation(),
        new DeleteGroupByIdTeamChannelByIdMemberByIdOperation(),
        new GetGroupByIdTeamChannelByIdMemberByIdOperation(),
        new GetGroupByIdTeamChannelByIdMemberCountOperation(),
        new ListGroupByIdTeamChannelByIdMembersOperation(),
        new UpdateGroupByIdTeamChannelByIdMemberByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddGroupByIdTeamChannelByIdMemberRequestModel)
    };
}
