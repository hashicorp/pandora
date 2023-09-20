// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.AdministrativeUnits.Beta.AdministrativeUnit;

internal class Definition : ResourceDefinition
{
    public string Name => "AdministrativeUnit";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckAdministrativeUnitByIdMemberGroupOperation(),
        new CheckAdministrativeUnitByIdMemberObjectOperation(),
        new CreateAdministrativeUnitOperation(),
        new DeleteAdministrativeUnitByIdOperation(),
        new GetAdministrativeUnitByIdMemberGroupOperation(),
        new GetAdministrativeUnitByIdMemberObjectOperation(),
        new GetAdministrativeUnitByIdOperation(),
        new GetAdministrativeUnitCountOperation(),
        new GetAdministrativeUnitsByIdsOperation(),
        new GetAdministrativeUnitsUserOwnedObjectOperation(),
        new ListAdministrativeUnitsOperation(),
        new RestoreAdministrativeUnitByIdOperation(),
        new UpdateAdministrativeUnitByIdOperation(),
        new ValidateAdministrativeUnitsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckAdministrativeUnitByIdMemberGroupRequestModel),
        typeof(CheckAdministrativeUnitByIdMemberObjectRequestModel),
        typeof(GetAdministrativeUnitByIdMemberGroupRequestModel),
        typeof(GetAdministrativeUnitByIdMemberObjectRequestModel),
        typeof(GetAdministrativeUnitsByIdsRequestModel),
        typeof(GetAdministrativeUnitsUserOwnedObjectRequestModel),
        typeof(ValidateAdministrativeUnitsPropertyRequestModel)
    };
}
