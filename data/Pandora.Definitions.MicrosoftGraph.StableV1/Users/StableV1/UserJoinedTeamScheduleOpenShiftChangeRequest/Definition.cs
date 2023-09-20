// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamScheduleOpenShiftChangeRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamScheduleOpenShiftChangeRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestOperation(),
        new DeleteUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestByIdOperation(),
        new GetUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestByIdOperation(),
        new GetUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestCountOperation(),
        new ListUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestsOperation(),
        new UpdateUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
