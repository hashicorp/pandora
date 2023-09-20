// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeExtensionOperation(),
        new DeleteMeExtensionByIdOperation(),
        new GetMeExtensionByIdOperation(),
        new GetMeExtensionCountOperation(),
        new ListMeExtensionsOperation(),
        new UpdateMeExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
