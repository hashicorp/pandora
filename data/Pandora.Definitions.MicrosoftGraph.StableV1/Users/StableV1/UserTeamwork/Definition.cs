// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserTeamwork;

internal class Definition : ResourceDefinition
{
    public string Name => "UserTeamwork";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdTeamworkSendActivityNotificationOperation(),
        new DeleteUserByIdTeamworkOperation(),
        new GetUserByIdTeamworkOperation(),
        new UpdateUserByIdTeamworkOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdTeamworkSendActivityNotificationRequestModel)
    };
}
