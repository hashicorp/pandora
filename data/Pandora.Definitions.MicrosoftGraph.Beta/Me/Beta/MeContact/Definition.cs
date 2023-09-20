// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeContact;

internal class Definition : ResourceDefinition
{
    public string Name => "MeContact";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeContactOperation(),
        new DeleteMeContactByIdOperation(),
        new GetMeContactByIdOperation(),
        new GetMeContactCountOperation(),
        new ListMeContactsOperation(),
        new UpdateMeContactByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
