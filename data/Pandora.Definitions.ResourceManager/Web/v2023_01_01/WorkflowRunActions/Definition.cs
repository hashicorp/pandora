using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WorkflowRunActions;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowRunActions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CopeRepetitionsGetOperation(),
        new CopeRepetitionsListOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListExpressionTracesOperation(),
        new WorkflowRunActionRepetitionsGetOperation(),
        new WorkflowRunActionRepetitionsListOperation(),
        new WorkflowRunActionRepetitionsListExpressionTracesOperation(),
        new WorkflowRunActionRepetitionsRequestHistoriesGetOperation(),
        new WorkflowRunActionRepetitionsRequestHistoriesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(WorkflowStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(ErrorPropertiesModel),
        typeof(ErrorResponseModel),
        typeof(RepetitionIndexModel),
        typeof(RequestModel),
        typeof(RequestHistoryModel),
        typeof(RequestHistoryPropertiesModel),
        typeof(ResponseModel),
        typeof(RetryHistoryModel),
        typeof(RunActionCorrelationModel),
        typeof(WorkflowRunActionModel),
        typeof(WorkflowRunActionPropertiesModel),
        typeof(WorkflowRunActionRepetitionDefinitionModel),
        typeof(WorkflowRunActionRepetitionPropertiesModel),
    };
}
