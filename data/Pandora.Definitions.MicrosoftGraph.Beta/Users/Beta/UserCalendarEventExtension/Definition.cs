// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdExtensionOperation(),
        new CreateUserByIdCalendarEventByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdEventByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarEventByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdExtensionCountOperation(),
        new GetUserByIdCalendarEventByIdExtensionByIdOperation(),
        new GetUserByIdCalendarEventByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdEventByIdExtensionsOperation(),
        new ListUserByIdCalendarEventByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdEventByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarEventByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
