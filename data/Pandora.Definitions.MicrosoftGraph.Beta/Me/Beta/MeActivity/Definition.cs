// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeActivity;

internal class Definition : ResourceDefinition
{
    public string Name => "MeActivity";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeActivityOperation(),
        new DeleteMeActivityByIdOperation(),
        new GetMeActivityByIdOperation(),
        new GetMeActivityCountOperation(),
        new ListMeActivitiesOperation(),
        new UpdateMeActivityByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
