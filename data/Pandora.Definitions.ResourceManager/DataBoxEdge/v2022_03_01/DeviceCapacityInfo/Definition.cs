using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;

internal class Definition : ResourceDefinition
{
    public string Name => "DeviceCapacityInfo";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetDeviceCapacityInfoOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterCapacityViewDataModel),
        typeof(ClusterGpuCapacityModel),
        typeof(ClusterMemoryCapacityModel),
        typeof(ClusterStorageViewDataModel),
        typeof(DeviceCapacityInfoModel),
        typeof(DeviceCapacityInfoPropertiesModel),
        typeof(HostCapacityModel),
        typeof(NumaNodeDataModel),
        typeof(VMMemoryModel),
    };
}
