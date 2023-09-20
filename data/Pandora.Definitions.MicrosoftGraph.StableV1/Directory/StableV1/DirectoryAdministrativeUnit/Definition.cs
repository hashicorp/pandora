// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryAdministrativeUnit;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryAdministrativeUnit";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryAdministrativeUnitOperation(),
        new DeleteDirectoryAdministrativeUnitByIdOperation(),
        new GetDirectoryAdministrativeUnitByIdOperation(),
        new GetDirectoryAdministrativeUnitCountOperation(),
        new ListDirectoryAdministrativeUnitsOperation(),
        new UpdateDirectoryAdministrativeUnitByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
