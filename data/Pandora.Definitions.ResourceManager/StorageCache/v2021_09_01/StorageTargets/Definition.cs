using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.StorageTargets;

internal class Definition : ResourceDefinition
{
    public string Name => "StorageTargets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DnsRefreshOperation(),
        new GetOperation(),
        new ListByCacheOperation(),
        new StorageTargetFlushOperation(),
        new StorageTargetResumeOperation(),
        new StorageTargetSuspendOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationalStateTypeConstant),
        typeof(ProvisioningStateTypeConstant),
        typeof(StorageTargetTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlobNfsTargetModel),
        typeof(ClfsTargetModel),
        typeof(NamespaceJunctionModel),
        typeof(Nfs3TargetModel),
        typeof(StorageTargetModel),
        typeof(StorageTargetPropertiesModel),
        typeof(UnknownTargetModel),
    };
}
