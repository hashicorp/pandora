using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.QumuloStorage.v2022_10_12.FileSystems;

internal class Definition : ResourceDefinition
{
    public string Name => "FileSystems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MarketplaceSubscriptionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(StorageSkuConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FileSystemResourceModel),
        typeof(FileSystemResourcePropertiesModel),
        typeof(FileSystemResourceUpdateModel),
        typeof(FileSystemResourceUpdatePropertiesModel),
        typeof(MarketplaceDetailsModel),
        typeof(UserDetailsModel),
    };
}
