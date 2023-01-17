using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;

internal class Definition : ResourceDefinition
{
    public string Name => "Labs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClaimAnyVMOperation(),
        new CreateEnvironmentOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExportResourceUsageOperation(),
        new GenerateUploadUriOperation(),
        new GetOperation(),
        new ImportVirtualMachineOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListVhdsOperation(),
        new UpdateOperation(),
    };
}
