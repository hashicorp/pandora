// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserPlannerPlan;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPlannerPlan";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPlannerPlanOperation(),
        new DeleteUserByIdPlannerPlanByIdOperation(),
        new GetUserByIdPlannerPlanByIdOperation(),
        new GetUserByIdPlannerPlanCountOperation(),
        new ListUserByIdPlannerPlansOperation(),
        new UpdateUserByIdPlannerPlanByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
