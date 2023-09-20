// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamScheduleTimeOffReason;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamScheduleTimeOffReason";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdScheduleTimeOffReasonOperation(),
        new DeleteMeJoinedTeamByIdScheduleTimeOffReasonByIdOperation(),
        new GetMeJoinedTeamByIdScheduleTimeOffReasonByIdOperation(),
        new GetMeJoinedTeamByIdScheduleTimeOffReasonCountOperation(),
        new ListMeJoinedTeamByIdScheduleTimeOffReasonsOperation(),
        new UpdateMeJoinedTeamByIdScheduleTimeOffReasonByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
