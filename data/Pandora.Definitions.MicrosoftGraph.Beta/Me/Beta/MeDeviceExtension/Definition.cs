// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeDeviceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeDeviceByIdExtensionOperation(),
        new DeleteMeDeviceByIdExtensionByIdOperation(),
        new GetMeDeviceByIdExtensionByIdOperation(),
        new GetMeDeviceByIdExtensionCountOperation(),
        new ListMeDeviceByIdExtensionsOperation(),
        new UpdateMeDeviceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
