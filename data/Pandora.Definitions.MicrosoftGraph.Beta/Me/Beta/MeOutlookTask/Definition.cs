// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTask;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOutlookTask";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOutlookTaskOperation(),
        new DeleteMeOutlookTaskByIdOperation(),
        new GetMeOutlookTaskByIdOperation(),
        new GetMeOutlookTaskCountOperation(),
        new ListMeOutlookTaskByIdCompletesOperation(),
        new ListMeOutlookTasksOperation(),
        new UpdateMeOutlookTaskByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
