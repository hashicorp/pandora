using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.PipelineRuns;

internal class Definition : ResourceDefinition
{
    public string Name => "PipelineRuns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PipelineRunSourceTypeConstant),
        typeof(PipelineRunTargetTypeConstant),
        typeof(PipelineSourceTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExportPipelineTargetPropertiesModel),
        typeof(ImportPipelineSourcePropertiesModel),
        typeof(PipelineRunModel),
        typeof(PipelineRunPropertiesModel),
        typeof(PipelineRunRequestModel),
        typeof(PipelineRunResponseModel),
        typeof(PipelineRunSourcePropertiesModel),
        typeof(PipelineRunTargetPropertiesModel),
        typeof(PipelineSourceTriggerDescriptorModel),
        typeof(PipelineTriggerDescriptorModel),
        typeof(ProgressPropertiesModel),
    };
}
