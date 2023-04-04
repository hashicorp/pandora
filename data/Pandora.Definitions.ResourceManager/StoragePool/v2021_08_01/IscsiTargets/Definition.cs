using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets;

internal class Definition : ResourceDefinition
{
    public string Name => "IscsiTargets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDiskPoolOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IscsiTargetAclModeConstant),
        typeof(OperationalStatusConstant),
        typeof(ProvisioningStatesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AclModel),
        typeof(IscsiLunModel),
        typeof(IscsiTargetModel),
        typeof(IscsiTargetCreateModel),
        typeof(IscsiTargetCreatePropertiesModel),
        typeof(IscsiTargetPropertiesModel),
        typeof(IscsiTargetUpdateModel),
        typeof(IscsiTargetUpdatePropertiesModel),
    };
}
