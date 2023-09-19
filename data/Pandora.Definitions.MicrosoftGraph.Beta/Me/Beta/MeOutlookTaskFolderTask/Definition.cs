// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskFolderTask;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOutlookTaskFolderTask";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOutlookTaskFolderByIdTaskOperation(),
        new DeleteMeOutlookTaskFolderByIdTaskByIdOperation(),
        new GetMeOutlookTaskFolderByIdTaskByIdOperation(),
        new GetMeOutlookTaskFolderByIdTaskCountOperation(),
        new ListMeOutlookTaskFolderByIdTaskByIdCompletesOperation(),
        new ListMeOutlookTaskFolderByIdTasksOperation(),
        new UpdateMeOutlookTaskFolderByIdTaskByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
