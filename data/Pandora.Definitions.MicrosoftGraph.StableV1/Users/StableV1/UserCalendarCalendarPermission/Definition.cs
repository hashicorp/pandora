// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarCalendarPermission;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarPermission";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarPermissionOperation(),
        new CreateUserByIdCalendarCalendarPermissionOperation(),
        new DeleteUserByIdCalendarByIdCalendarPermissionByIdOperation(),
        new DeleteUserByIdCalendarCalendarPermissionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarPermissionByIdOperation(),
        new GetUserByIdCalendarByIdCalendarPermissionCountOperation(),
        new GetUserByIdCalendarCalendarPermissionByIdOperation(),
        new GetUserByIdCalendarCalendarPermissionCountOperation(),
        new ListUserByIdCalendarByIdCalendarPermissionsOperation(),
        new ListUserByIdCalendarCalendarPermissionsOperation(),
        new UpdateUserByIdCalendarByIdCalendarPermissionByIdOperation(),
        new UpdateUserByIdCalendarCalendarPermissionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
