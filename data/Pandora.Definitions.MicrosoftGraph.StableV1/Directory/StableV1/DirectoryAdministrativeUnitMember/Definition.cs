// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryAdministrativeUnitMember;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryAdministrativeUnitMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddDirectoryAdministrativeUnitByIdMemberRefOperation(),
        new CreateDirectoryAdministrativeUnitByIdMemberOperation(),
        new GetDirectoryAdministrativeUnitByIdMemberCountOperation(),
        new ListDirectoryAdministrativeUnitByIdMemberRefsOperation(),
        new ListDirectoryAdministrativeUnitByIdMembersOperation(),
        new RemoveDirectoryAdministrativeUnitByIdMemberByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
