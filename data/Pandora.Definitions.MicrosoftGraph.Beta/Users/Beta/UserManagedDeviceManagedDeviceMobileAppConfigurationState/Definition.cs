// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDeviceManagedDeviceMobileAppConfigurationState;

internal class Definition : ResourceDefinition
{
    public string Name => "UserManagedDeviceManagedDeviceMobileAppConfigurationState";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdManagedDeviceByIdManagedDeviceMobileAppConfigurationStateOperation(),
        new DeleteUserByIdManagedDeviceByIdManagedDeviceMobileAppConfigurationStateByIdOperation(),
        new GetUserByIdManagedDeviceByIdManagedDeviceMobileAppConfigurationStateByIdOperation(),
        new GetUserByIdManagedDeviceByIdManagedDeviceMobileAppConfigurationStateCountOperation(),
        new ListUserByIdManagedDeviceByIdManagedDeviceMobileAppConfigurationStatesOperation(),
        new UpdateUserByIdManagedDeviceByIdManagedDeviceMobileAppConfigurationStateByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
