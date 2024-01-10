// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPlannerPlan;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupPlannerPlan";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdPlannerPlanOperation(),
        new DeleteGroupByIdPlannerPlanByIdOperation(),
        new GetGroupByIdPlannerPlanByIdOperation(),
        new GetGroupByIdPlannerPlanCountOperation(),
        new ListGroupByIdPlannerPlansOperation(),
        new UpdateGroupByIdPlannerPlanByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
