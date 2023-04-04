using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.LocationBasedCapabilities;

internal class Definition : ResourceDefinition
{
    public string Name => "LocationBasedCapabilities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExecuteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapabilityPropertiesModel),
        typeof(FastProvisioningEditionCapabilityModel),
        typeof(FlexibleServerEditionCapabilityModel),
        typeof(HyperscaleNodeEditionCapabilityModel),
        typeof(NodeTypeCapabilityModel),
        typeof(ServerVersionCapabilityModel),
        typeof(StorageEditionCapabilityModel),
        typeof(StorageMBCapabilityModel),
        typeof(StorageTierCapabilityModel),
        typeof(VcoreCapabilityModel),
    };
}
