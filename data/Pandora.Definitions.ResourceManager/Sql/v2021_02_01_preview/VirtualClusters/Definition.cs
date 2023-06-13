using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.VirtualClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
        new UpdateDnsServersOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DnsRefreshConfigurationPropertiesModel),
        typeof(UpdateManagedInstanceDnsServersOperationModel),
        typeof(VirtualClusterModel),
        typeof(VirtualClusterPropertiesModel),
        typeof(VirtualClusterUpdateModel),
    };
}
