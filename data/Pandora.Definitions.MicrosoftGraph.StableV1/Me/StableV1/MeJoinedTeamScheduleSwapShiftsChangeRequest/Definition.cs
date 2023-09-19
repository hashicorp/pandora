// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamScheduleSwapShiftsChangeRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamScheduleSwapShiftsChangeRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdScheduleSwapShiftsChangeRequestOperation(),
        new DeleteMeJoinedTeamByIdScheduleSwapShiftsChangeRequestByIdOperation(),
        new GetMeJoinedTeamByIdScheduleSwapShiftsChangeRequestByIdOperation(),
        new GetMeJoinedTeamByIdScheduleSwapShiftsChangeRequestCountOperation(),
        new ListMeJoinedTeamByIdScheduleSwapShiftsChangeRequestsOperation(),
        new UpdateMeJoinedTeamByIdScheduleSwapShiftsChangeRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
