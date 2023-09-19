// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPlannerAll;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPlannerAll";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPlannerAllOperation(),
        new DeleteUserByIdPlannerAllByIdOperation(),
        new GetUserByIdPlannerAllByIdOperation(),
        new GetUserByIdPlannerAllCountOperation(),
        new ListUserByIdPlannerAllsOperation(),
        new UpdateUserByIdPlannerAllByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
