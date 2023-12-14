// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdExtensionOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdEventByIdInstanceByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarEventByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdExtensionCountOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExtensionByIdOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdEventByIdInstanceByIdExtensionsOperation(),
        new ListUserByIdCalendarEventByIdInstanceByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdEventByIdInstanceByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarEventByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
