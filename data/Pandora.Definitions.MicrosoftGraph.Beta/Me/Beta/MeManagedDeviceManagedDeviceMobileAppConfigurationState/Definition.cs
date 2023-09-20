// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceManagedDeviceMobileAppConfigurationState;

internal class Definition : ResourceDefinition
{
    public string Name => "MeManagedDeviceManagedDeviceMobileAppConfigurationState";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeManagedDeviceByIdManagedDeviceMobileAppConfigurationStateOperation(),
        new DeleteMeManagedDeviceByIdManagedDeviceMobileAppConfigurationStateByIdOperation(),
        new GetMeManagedDeviceByIdManagedDeviceMobileAppConfigurationStateByIdOperation(),
        new GetMeManagedDeviceByIdManagedDeviceMobileAppConfigurationStateCountOperation(),
        new ListMeManagedDeviceByIdManagedDeviceMobileAppConfigurationStatesOperation(),
        new UpdateMeManagedDeviceByIdManagedDeviceMobileAppConfigurationStateByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
