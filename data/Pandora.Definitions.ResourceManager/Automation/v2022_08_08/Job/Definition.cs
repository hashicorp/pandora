using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Job;

internal class Definition : ResourceDefinition
{
    public string Name => "Job";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new GetOutputOperation(),
        new GetRunbookContentOperation(),
        new ListByAutomationAccountOperation(),
        new ResumeOperation(),
        new StopOperation(),
        new SuspendOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(JobProvisioningStateConstant),
        typeof(JobStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(JobModel),
        typeof(JobCollectionItemModel),
        typeof(JobCollectionItemPropertiesModel),
        typeof(JobCreateParametersModel),
        typeof(JobCreatePropertiesModel),
        typeof(JobPropertiesModel),
        typeof(RunbookAssociationPropertyModel),
    };
}
