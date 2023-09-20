// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileAccount;

internal class Definition : ResourceDefinition
{
    public string Name => "MeProfileAccount";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeProfileAccountOperation(),
        new DeleteMeProfileAccountByIdOperation(),
        new GetMeProfileAccountByIdOperation(),
        new GetMeProfileAccountCountOperation(),
        new ListMeProfileAccountsOperation(),
        new UpdateMeProfileAccountByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
