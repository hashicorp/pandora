using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.JobTargetExecutions;

internal class Definition : ResourceDefinition
{
    public string Name => "JobTargetExecutions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByJobExecutionOperation(),
        new ListByStepOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(JobExecutionLifecycleConstant),
        typeof(JobTargetTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(JobExecutionModel),
        typeof(JobExecutionPropertiesModel),
        typeof(JobExecutionTargetModel),
    };
}
