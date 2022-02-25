using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.Databases;

internal class Definition : ResourceDefinition
{
    public string Name => "Databases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ExportOperation(),
        new ForceUnlinkOperation(),
        new GetOperation(),
        new ImportOperation(),
        new ListByClusterOperation(),
        new ListKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
}
