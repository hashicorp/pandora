// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserLicenseDetail;

internal class Definition : ResourceDefinition
{
    public string Name => "UserLicenseDetail";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdLicenseDetailOperation(),
        new DeleteUserByIdLicenseDetailByIdOperation(),
        new GetUserByIdLicenseDetailByIdOperation(),
        new GetUserByIdLicenseDetailCountOperation(),
        new ListUserByIdLicenseDetailsOperation(),
        new UpdateUserByIdLicenseDetailByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
