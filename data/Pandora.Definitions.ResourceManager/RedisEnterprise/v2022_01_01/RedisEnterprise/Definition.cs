using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

internal class Definition : ResourceDefinition
{
    public string Name => "RedisEnterprise";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DatabasesCreateOperation(),
        new DatabasesDeleteOperation(),
        new DatabasesExportOperation(),
        new DatabasesForceUnlinkOperation(),
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
