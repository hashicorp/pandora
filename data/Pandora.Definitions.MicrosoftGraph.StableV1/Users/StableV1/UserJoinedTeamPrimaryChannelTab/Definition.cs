// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelTab;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamPrimaryChannelTab";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdJoinedTeamByIdPrimaryChannelTabOperation(),
        new DeleteUserByIdJoinedTeamByIdPrimaryChannelTabByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelTabByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelTabCountOperation(),
        new ListUserByIdJoinedTeamByIdPrimaryChannelTabsOperation(),
        new UpdateUserByIdJoinedTeamByIdPrimaryChannelTabByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
