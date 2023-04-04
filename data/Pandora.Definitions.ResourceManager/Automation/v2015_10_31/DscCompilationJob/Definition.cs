using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.DscCompilationJob;

internal class Definition : ResourceDefinition
{
    public string Name => "DscCompilationJob";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new GetStreamOperation(),
        new ListByAutomationAccountOperation(),
        new StreamListByJobOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(JobProvisioningStateConstant),
        typeof(JobStatusConstant),
        typeof(JobStreamTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DscCompilationJobModel),
        typeof(DscCompilationJobCreateParametersModel),
        typeof(DscCompilationJobCreatePropertiesModel),
        typeof(DscCompilationJobPropertiesModel),
        typeof(DscConfigurationAssociationPropertyModel),
        typeof(JobStreamModel),
        typeof(JobStreamListResultModel),
        typeof(JobStreamPropertiesModel),
    };
}
