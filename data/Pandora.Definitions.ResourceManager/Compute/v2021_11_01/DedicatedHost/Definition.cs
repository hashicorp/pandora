using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.DedicatedHost;

internal class Definition : ResourceDefinition
{
    public string Name => "DedicatedHost";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByHostGroupOperation(),
        new RestartOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DedicatedHostLicenseTypesConstant),
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DedicatedHostModel),
        typeof(DedicatedHostAllocatableVMModel),
        typeof(DedicatedHostAvailableCapacityModel),
        typeof(DedicatedHostInstanceViewModel),
        typeof(DedicatedHostPropertiesModel),
        typeof(InstanceViewStatusModel),
        typeof(SkuModel),
        typeof(SubResourceReadOnlyModel),
    };
}
