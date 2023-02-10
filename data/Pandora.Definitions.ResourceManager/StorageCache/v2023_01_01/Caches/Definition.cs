using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;

internal class Definition : ResourceDefinition
{
    public string Name => "Caches";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DebugInfoOperation(),
        new DeleteOperation(),
        new FlushOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new PausePrimingJobOperation(),
        new ResumePrimingJobOperation(),
        new SpaceAllocationOperation(),
        new StartOperation(),
        new StartPrimingJobOperation(),
        new StopOperation(),
        new StopPrimingJobOperation(),
        new UpdateOperation(),
        new UpgradeFirmwareOperation(),
    };
}
