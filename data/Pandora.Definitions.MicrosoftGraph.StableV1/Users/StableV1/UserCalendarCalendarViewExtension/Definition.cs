// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarCalendarViewExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdExtensionOperation(),
        new CreateUserByIdCalendarCalendarViewByIdExtensionOperation(),
        new DeleteUserByIdCalendarByIdCalendarViewByIdExtensionByIdOperation(),
        new DeleteUserByIdCalendarCalendarViewByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExtensionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdExtensionCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdExtensionByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdExtensionCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdExtensionsOperation(),
        new ListUserByIdCalendarCalendarViewByIdExtensionsOperation(),
        new UpdateUserByIdCalendarByIdCalendarViewByIdExtensionByIdOperation(),
        new UpdateUserByIdCalendarCalendarViewByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
