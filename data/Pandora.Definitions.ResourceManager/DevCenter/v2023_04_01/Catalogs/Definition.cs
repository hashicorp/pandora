using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Catalogs;

internal class Definition : ResourceDefinition
{
    public string Name => "Catalogs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDevCenterOperation(),
        new SyncOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CatalogSyncStateConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CatalogModel),
        typeof(CatalogPropertiesModel),
        typeof(CatalogUpdateModel),
        typeof(CatalogUpdatePropertiesModel),
        typeof(GitCatalogModel),
    };
}
