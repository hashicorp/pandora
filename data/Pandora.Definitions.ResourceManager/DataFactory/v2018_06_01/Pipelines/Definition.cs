using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Pipelines;

internal class Definition : ResourceDefinition
{
    public string Name => "Pipelines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateRunOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByFactoryOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DependencyConditionConstant),
        typeof(ParameterTypeConstant),
        typeof(VariableTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActivityModel),
        typeof(ActivityDependencyModel),
        typeof(CreateRunResponseModel),
        typeof(ParameterSpecificationModel),
        typeof(PipelineModel),
        typeof(PipelineElapsedTimeMetricPolicyModel),
        typeof(PipelineFolderModel),
        typeof(PipelinePolicyModel),
        typeof(PipelineResourceModel),
        typeof(UserPropertyModel),
        typeof(VariableSpecificationModel),
    };
}
