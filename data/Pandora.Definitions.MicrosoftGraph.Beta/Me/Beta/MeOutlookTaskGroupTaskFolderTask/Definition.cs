// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskGroupTaskFolderTask;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOutlookTaskGroupTaskFolderTask";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOutlookTaskGroupByIdTaskFolderByIdTaskOperation(),
        new DeleteMeOutlookTaskGroupByIdTaskFolderByIdTaskByIdOperation(),
        new GetMeOutlookTaskGroupByIdTaskFolderByIdTaskByIdOperation(),
        new GetMeOutlookTaskGroupByIdTaskFolderByIdTaskCountOperation(),
        new ListMeOutlookTaskGroupByIdTaskFolderByIdTaskByIdCompletesOperation(),
        new ListMeOutlookTaskGroupByIdTaskFolderByIdTasksOperation(),
        new UpdateMeOutlookTaskGroupByIdTaskFolderByIdTaskByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
