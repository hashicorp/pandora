// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePlannerTask;

internal class Definition : ResourceDefinition
{
    public string Name => "MePlannerTask";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePlannerTaskOperation(),
        new DeleteMePlannerTaskByIdOperation(),
        new GetMePlannerTaskByIdOperation(),
        new GetMePlannerTaskCountOperation(),
        new ListMePlannerTasksOperation(),
        new UpdateMePlannerTaskByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
