// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarCalendarViewInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionsOperation(),
        new ListUserByIdCalendarCalendarViewByIdInstanceByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdCalendarViewByIdInstanceByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarCalendarViewByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
