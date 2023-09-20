// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamMember;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddMeJoinedTeamByIdMemberOperation(),
        new CreateMeJoinedTeamByIdMemberOperation(),
        new DeleteMeJoinedTeamByIdMemberByIdOperation(),
        new GetMeJoinedTeamByIdMemberByIdOperation(),
        new GetMeJoinedTeamByIdMemberCountOperation(),
        new ListMeJoinedTeamByIdMembersOperation(),
        new UpdateMeJoinedTeamByIdMemberByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddMeJoinedTeamByIdMemberRequestModel)
    };
}
