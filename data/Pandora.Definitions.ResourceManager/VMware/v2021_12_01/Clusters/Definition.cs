using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClusterProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterModel),
        typeof(ClusterUpdateModel),
        typeof(ClusterUpdatePropertiesModel),
        typeof(CommonClusterPropertiesModel),
        typeof(SkuModel),
    };
}
