// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePlannerPlan;

internal class Definition : ResourceDefinition
{
    public string Name => "MePlannerPlan";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePlannerPlanByIdMoveToContainerOperation(),
        new CreateMePlannerPlanOperation(),
        new DeleteMePlannerPlanByIdOperation(),
        new GetMePlannerPlanByIdOperation(),
        new GetMePlannerPlanCountOperation(),
        new ListMePlannerPlansOperation(),
        new UpdateMePlannerPlanByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMePlannerPlanByIdMoveToContainerRequestModel)
    };
}
