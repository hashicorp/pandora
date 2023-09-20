// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnlineMeeting;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnlineMeeting";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnlineMeetingCreateOrGetOperation(),
        new CreateUserByIdOnlineMeetingOperation(),
        new DeleteUserByIdOnlineMeetingByIdOperation(),
        new GetUserByIdOnlineMeetingByIdOperation(),
        new GetUserByIdOnlineMeetingCountOperation(),
        new ListUserByIdOnlineMeetingsOperation(),
        new UpdateUserByIdOnlineMeetingByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnlineMeetingCreateOrGetRequestModel)
    };
}
