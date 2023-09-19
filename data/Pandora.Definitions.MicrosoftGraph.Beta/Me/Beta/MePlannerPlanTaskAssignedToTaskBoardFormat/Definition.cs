// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePlannerPlanTaskAssignedToTaskBoardFormat;

internal class Definition : ResourceDefinition
{
    public string Name => "MePlannerPlanTaskAssignedToTaskBoardFormat";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteMePlannerPlanByIdTaskByIdAssignedToTaskBoardFormatOperation(),
        new GetMePlannerPlanByIdTaskByIdAssignedToTaskBoardFormatOperation(),
        new UpdateMePlannerPlanByIdTaskByIdAssignedToTaskBoardFormatOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
