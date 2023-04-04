using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.SourceControlSyncJob;

internal class Definition : ResourceDefinition
{
    public string Name => "SourceControlSyncJob";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new ListByAutomationAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(SyncTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SourceControlSyncJobModel),
        typeof(SourceControlSyncJobByIdModel),
        typeof(SourceControlSyncJobByIdPropertiesModel),
        typeof(SourceControlSyncJobCreateParametersModel),
        typeof(SourceControlSyncJobCreatePropertiesModel),
        typeof(SourceControlSyncJobPropertiesModel),
    };
}
