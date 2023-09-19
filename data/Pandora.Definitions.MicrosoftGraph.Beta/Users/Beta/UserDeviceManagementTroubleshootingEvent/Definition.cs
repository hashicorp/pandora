// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceManagementTroubleshootingEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserDeviceManagementTroubleshootingEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdDeviceManagementTroubleshootingEventOperation(),
        new DeleteUserByIdDeviceManagementTroubleshootingEventByIdOperation(),
        new GetUserByIdDeviceManagementTroubleshootingEventByIdOperation(),
        new GetUserByIdDeviceManagementTroubleshootingEventCountOperation(),
        new ListUserByIdDeviceManagementTroubleshootingEventsOperation(),
        new UpdateUserByIdDeviceManagementTroubleshootingEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
