using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowTriggers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetSchemaJsonOperation(),
        new ListOperation(),
        new ListCallbackUrlOperation(),
        new ResetOperation(),
        new RunOperation(),
        new SetStateOperation(),
        new WorkflowVersionTriggersListCallbackUrlOperation(),
    };
}
