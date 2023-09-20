// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPresence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPresence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPresenceClearPresenceOperation(),
        new CreateUserByIdPresenceClearUserPreferredPresenceOperation(),
        new DeleteUserByIdPresenceOperation(),
        new GetUserByIdPresenceOperation(),
        new SetUserByIdPresencePresenceOperation(),
        new SetUserByIdPresenceStatusMessageOperation(),
        new SetUserByIdPresenceUserPreferredPresenceOperation(),
        new UpdateUserByIdPresenceOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdPresenceClearPresenceRequestModel),
        typeof(SetUserByIdPresencePresenceRequestModel),
        typeof(SetUserByIdPresenceStatusMessageRequestModel),
        typeof(SetUserByIdPresenceUserPreferredPresenceRequestModel)
    };
}
