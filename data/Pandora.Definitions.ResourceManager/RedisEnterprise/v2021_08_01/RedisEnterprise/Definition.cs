using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise;

internal class Definition : ResourceDefinition
{
    public string Name => "RedisEnterprise";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DatabasesCreateOperation(),
        new DatabasesDeleteOperation(),
        new DatabasesExportOperation(),
        new DatabasesGetOperation(),
        new DatabasesImportOperation(),
        new DatabasesListByClusterOperation(),
        new DatabasesListKeysOperation(),
        new DatabasesRegenerateKeyOperation(),
        new DatabasesUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
}
