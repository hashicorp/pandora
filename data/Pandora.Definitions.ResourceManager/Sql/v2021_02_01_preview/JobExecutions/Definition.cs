using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.JobExecutions;

internal class Definition : ResourceDefinition
{
    public string Name => "JobExecutions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOperation(),
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByAgentOperation(),
        new ListByJobOperation(),
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
