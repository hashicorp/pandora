using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.CapacityPools;

internal class Definition : ResourceDefinition
{
    public string Name => "CapacityPools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PoolsCreateOrUpdateOperation(),
        new PoolsDeleteOperation(),
        new PoolsGetOperation(),
        new PoolsListOperation(),
        new PoolsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EncryptionTypeConstant),
        typeof(QosTypeConstant),
        typeof(ServiceLevelConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapacityPoolModel),
        typeof(CapacityPoolPatchModel),
        typeof(PoolPatchPropertiesModel),
        typeof(PoolPropertiesModel),
    };
}
