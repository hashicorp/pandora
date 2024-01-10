// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileSkill;

internal class Definition : ResourceDefinition
{
    public string Name => "UserProfileSkill";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdProfileSkillOperation(),
        new DeleteUserByIdProfileSkillByIdOperation(),
        new GetUserByIdProfileSkillByIdOperation(),
        new GetUserByIdProfileSkillCountOperation(),
        new ListUserByIdProfileSkillsOperation(),
        new UpdateUserByIdProfileSkillByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
