// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamScheduleOpenShift;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamScheduleOpenShift";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamScheduleOpenShiftOperation(),
        new DeleteGroupByIdTeamScheduleOpenShiftByIdOperation(),
        new GetGroupByIdTeamScheduleOpenShiftByIdOperation(),
        new GetGroupByIdTeamScheduleOpenShiftCountOperation(),
        new ListGroupByIdTeamScheduleOpenShiftsOperation(),
        new UpdateGroupByIdTeamScheduleOpenShiftByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
