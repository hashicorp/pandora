// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryAdministrativeUnit;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryAdministrativeUnit";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckDirectoryAdministrativeUnitByIdMemberGroupOperation(),
        new CheckDirectoryAdministrativeUnitByIdMemberObjectOperation(),
        new CreateDirectoryAdministrativeUnitOperation(),
        new DeleteDirectoryAdministrativeUnitByIdOperation(),
        new GetDirectoryAdministrativeUnitByIdMemberGroupOperation(),
        new GetDirectoryAdministrativeUnitByIdMemberObjectOperation(),
        new GetDirectoryAdministrativeUnitByIdOperation(),
        new GetDirectoryAdministrativeUnitCountOperation(),
        new GetDirectoryAdministrativeUnitsByIdsOperation(),
        new GetDirectoryAdministrativeUnitsUserOwnedObjectOperation(),
        new ListDirectoryAdministrativeUnitsOperation(),
        new RestoreDirectoryAdministrativeUnitByIdOperation(),
        new UpdateDirectoryAdministrativeUnitByIdOperation(),
        new ValidateDirectoryAdministrativeUnitsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckDirectoryAdministrativeUnitByIdMemberGroupRequestModel),
        typeof(CheckDirectoryAdministrativeUnitByIdMemberObjectRequestModel),
        typeof(GetDirectoryAdministrativeUnitByIdMemberGroupRequestModel),
        typeof(GetDirectoryAdministrativeUnitByIdMemberObjectRequestModel),
        typeof(GetDirectoryAdministrativeUnitsByIdsRequestModel),
        typeof(GetDirectoryAdministrativeUnitsUserOwnedObjectRequestModel),
        typeof(ValidateDirectoryAdministrativeUnitsPropertyRequestModel)
    };
}
