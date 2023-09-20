// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamScheduleShift;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamScheduleShift";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamScheduleShiftOperation(),
        new DeleteGroupByIdTeamScheduleShiftByIdOperation(),
        new GetGroupByIdTeamScheduleShiftByIdOperation(),
        new GetGroupByIdTeamScheduleShiftCountOperation(),
        new ListGroupByIdTeamScheduleShiftsOperation(),
        new UpdateGroupByIdTeamScheduleShiftByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
