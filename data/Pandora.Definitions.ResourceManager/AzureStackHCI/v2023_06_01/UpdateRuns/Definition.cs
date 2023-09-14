using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.UpdateRuns;

internal class Definition : ResourceDefinition
{
    public string Name => "UpdateRuns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new PutOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(UpdateRunPropertiesStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(StepModel),
        typeof(UpdateRunModel),
        typeof(UpdateRunPropertiesModel),
    };
}
