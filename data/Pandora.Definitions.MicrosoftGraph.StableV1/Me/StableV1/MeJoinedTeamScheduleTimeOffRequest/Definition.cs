// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamScheduleTimeOffRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamScheduleTimeOffRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdScheduleTimeOffRequestOperation(),
        new DeleteMeJoinedTeamByIdScheduleTimeOffRequestByIdOperation(),
        new GetMeJoinedTeamByIdScheduleTimeOffRequestByIdOperation(),
        new GetMeJoinedTeamByIdScheduleTimeOffRequestCountOperation(),
        new ListMeJoinedTeamByIdScheduleTimeOffRequestsOperation(),
        new UpdateMeJoinedTeamByIdScheduleTimeOffRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
