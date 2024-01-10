// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamScheduleOpenShift;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamScheduleOpenShift";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdScheduleOpenShiftOperation(),
        new DeleteMeJoinedTeamByIdScheduleOpenShiftByIdOperation(),
        new GetMeJoinedTeamByIdScheduleOpenShiftByIdOperation(),
        new GetMeJoinedTeamByIdScheduleOpenShiftCountOperation(),
        new ListMeJoinedTeamByIdScheduleOpenShiftsOperation(),
        new UpdateMeJoinedTeamByIdScheduleOpenShiftByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
