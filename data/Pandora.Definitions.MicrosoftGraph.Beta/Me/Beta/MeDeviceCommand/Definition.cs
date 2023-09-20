// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceCommand;

internal class Definition : ResourceDefinition
{
    public string Name => "MeDeviceCommand";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeDeviceByIdCommandOperation(),
        new DeleteMeDeviceByIdCommandByIdOperation(),
        new GetMeDeviceByIdCommandByIdOperation(),
        new GetMeDeviceByIdCommandCountOperation(),
        new ListMeDeviceByIdCommandsOperation(),
        new UpdateMeDeviceByIdCommandByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
