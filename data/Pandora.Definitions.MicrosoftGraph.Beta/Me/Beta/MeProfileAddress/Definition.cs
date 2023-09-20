// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileAddress;

internal class Definition : ResourceDefinition
{
    public string Name => "MeProfileAddress";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeProfileAddresOperation(),
        new DeleteMeProfileAddressByIdOperation(),
        new GetMeProfileAddressByIdOperation(),
        new GetMeProfileAddressCountOperation(),
        new ListMeProfileAddresOperation(),
        new UpdateMeProfileAddressByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
