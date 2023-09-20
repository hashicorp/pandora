// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamScheduleSwapShiftsChangeRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamScheduleSwapShiftsChangeRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamScheduleSwapShiftsChangeRequestOperation(),
        new DeleteGroupByIdTeamScheduleSwapShiftsChangeRequestByIdOperation(),
        new GetGroupByIdTeamScheduleSwapShiftsChangeRequestByIdOperation(),
        new GetGroupByIdTeamScheduleSwapShiftsChangeRequestCountOperation(),
        new ListGroupByIdTeamScheduleSwapShiftsChangeRequestsOperation(),
        new UpdateGroupByIdTeamScheduleSwapShiftsChangeRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
