// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeContactExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeContactExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeContactByIdExtensionOperation(),
        new DeleteMeContactByIdExtensionByIdOperation(),
        new GetMeContactByIdExtensionByIdOperation(),
        new GetMeContactByIdExtensionCountOperation(),
        new ListMeContactByIdExtensionsOperation(),
        new UpdateMeContactByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
