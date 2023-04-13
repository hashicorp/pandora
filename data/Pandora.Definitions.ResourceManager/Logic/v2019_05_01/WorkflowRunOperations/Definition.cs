using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowRunOperations;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowRunOperations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ParameterTypeConstant),
        typeof(WorkflowStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(CorrelationModel),
        typeof(ResourceReferenceModel),
        typeof(WorkflowOutputParameterModel),
        typeof(WorkflowRunModel),
        typeof(WorkflowRunPropertiesModel),
        typeof(WorkflowRunTriggerModel),
    };
}
