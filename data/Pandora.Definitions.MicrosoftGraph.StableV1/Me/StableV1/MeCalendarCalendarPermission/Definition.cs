// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarCalendarPermission;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarPermission";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarPermissionOperation(),
        new CreateMeCalendarCalendarPermissionOperation(),
        new DeleteMeCalendarByIdCalendarPermissionByIdOperation(),
        new DeleteMeCalendarCalendarPermissionByIdOperation(),
        new GetMeCalendarByIdCalendarPermissionByIdOperation(),
        new GetMeCalendarByIdCalendarPermissionCountOperation(),
        new GetMeCalendarCalendarPermissionByIdOperation(),
        new GetMeCalendarCalendarPermissionCountOperation(),
        new ListMeCalendarByIdCalendarPermissionsOperation(),
        new ListMeCalendarCalendarPermissionsOperation(),
        new UpdateMeCalendarByIdCalendarPermissionByIdOperation(),
        new UpdateMeCalendarCalendarPermissionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
