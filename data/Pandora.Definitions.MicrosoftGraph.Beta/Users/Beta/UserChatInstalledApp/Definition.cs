// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatInstalledApp;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatInstalledApp";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdChatByIdInstalledAppByIdUpgradeOperation(),
        new CreateUserByIdChatByIdInstalledAppOperation(),
        new DeleteUserByIdChatByIdInstalledAppByIdOperation(),
        new GetUserByIdChatByIdInstalledAppByIdOperation(),
        new GetUserByIdChatByIdInstalledAppCountOperation(),
        new ListUserByIdChatByIdInstalledAppsOperation(),
        new UpdateUserByIdChatByIdInstalledAppByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdChatByIdInstalledAppByIdUpgradeRequestModel)
    };
}
