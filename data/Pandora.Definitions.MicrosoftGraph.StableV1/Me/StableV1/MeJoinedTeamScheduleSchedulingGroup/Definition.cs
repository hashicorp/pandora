// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamScheduleSchedulingGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamScheduleSchedulingGroup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdScheduleSchedulingGroupOperation(),
        new DeleteMeJoinedTeamByIdScheduleSchedulingGroupByIdOperation(),
        new GetMeJoinedTeamByIdScheduleSchedulingGroupByIdOperation(),
        new GetMeJoinedTeamByIdScheduleSchedulingGroupCountOperation(),
        new ListMeJoinedTeamByIdScheduleSchedulingGroupsOperation(),
        new UpdateMeJoinedTeamByIdScheduleSchedulingGroupByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
