// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.AdministrativeUnits.Beta.AdministrativeUnitMember;

internal class Definition : ResourceDefinition
{
    public string Name => "AdministrativeUnitMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddAdministrativeUnitByIdMemberRefOperation(),
        new CreateAdministrativeUnitByIdMemberOperation(),
        new GetAdministrativeUnitByIdMemberCountOperation(),
        new ListAdministrativeUnitByIdMemberRefsOperation(),
        new ListAdministrativeUnitByIdMembersOperation(),
        new RemoveAdministrativeUnitByIdMemberByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
