using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.JobSteps;

internal class Definition : ResourceDefinition
{
    public string Name => "JobSteps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetByVersionOperation(),
        new ListByJobOperation(),
        new ListByVersionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(JobStepActionSourceConstant),
        typeof(JobStepActionTypeConstant),
        typeof(JobStepOutputTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(JobStepModel),
        typeof(JobStepActionModel),
        typeof(JobStepExecutionOptionsModel),
        typeof(JobStepOutputModel),
        typeof(JobStepPropertiesModel),
    };
}
