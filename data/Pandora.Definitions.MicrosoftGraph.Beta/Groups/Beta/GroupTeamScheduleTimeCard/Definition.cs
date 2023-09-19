// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamScheduleTimeCard;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamScheduleTimeCard";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamScheduleTimeCardByIdClockOutOperation(),
        new CreateGroupByIdTeamScheduleTimeCardByIdConfirmOperation(),
        new CreateGroupByIdTeamScheduleTimeCardByIdEndBreakOperation(),
        new CreateGroupByIdTeamScheduleTimeCardClockInOperation(),
        new CreateGroupByIdTeamScheduleTimeCardOperation(),
        new DeleteGroupByIdTeamScheduleTimeCardByIdOperation(),
        new GetGroupByIdTeamScheduleTimeCardByIdOperation(),
        new GetGroupByIdTeamScheduleTimeCardCountOperation(),
        new ListGroupByIdTeamScheduleTimeCardsOperation(),
        new StartGroupByIdTeamScheduleTimeCardByIdBreakOperation(),
        new UpdateGroupByIdTeamScheduleTimeCardByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdTeamScheduleTimeCardByIdClockOutRequestModel),
        typeof(CreateGroupByIdTeamScheduleTimeCardByIdEndBreakRequestModel),
        typeof(CreateGroupByIdTeamScheduleTimeCardClockInRequestModel),
        typeof(StartGroupByIdTeamScheduleTimeCardByIdBreakRequestModel)
    };
}
