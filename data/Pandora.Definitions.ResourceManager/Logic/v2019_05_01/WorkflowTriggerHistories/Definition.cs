using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggerHistories;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowTriggerHistories";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new ResubmitOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(WorkflowStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(CorrelationModel),
        typeof(ResourceReferenceModel),
        typeof(WorkflowTriggerHistoryModel),
        typeof(WorkflowTriggerHistoryPropertiesModel),
    };
}
