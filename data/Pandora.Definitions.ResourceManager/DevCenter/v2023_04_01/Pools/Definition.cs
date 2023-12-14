using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Pools;

internal class Definition : ResourceDefinition
{
    public string Name => "Pools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByProjectOperation(),
        new RunHealthChecksOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthStatusConstant),
        typeof(LicenseTypeConstant),
        typeof(LocalAdminStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(StopOnDisconnectEnableStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(HealthStatusDetailModel),
        typeof(PoolModel),
        typeof(PoolPropertiesModel),
        typeof(PoolUpdateModel),
        typeof(PoolUpdatePropertiesModel),
        typeof(StopOnDisconnectConfigurationModel),
    };
}
