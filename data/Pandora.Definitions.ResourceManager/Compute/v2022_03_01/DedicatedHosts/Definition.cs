using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.DedicatedHosts;

internal class Definition : ResourceDefinition
{
    public string Name => "DedicatedHosts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DedicatedHostLicenseTypesConstant),
        typeof(InstanceViewTypesConstant),
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DedicatedHostModel),
        typeof(DedicatedHostAllocatableVMModel),
        typeof(DedicatedHostAvailableCapacityModel),
        typeof(DedicatedHostInstanceViewModel),
        typeof(DedicatedHostPropertiesModel),
        typeof(DedicatedHostUpdateModel),
        typeof(InstanceViewStatusModel),
        typeof(SkuModel),
        typeof(SubResourceReadOnlyModel),
    };
}
