using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;

internal class Definition : ResourceDefinition
{
    public string Name => "FileShares";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new LeaseOperation(),
        new ListOperation(),
        new RestoreOperation(),
        new UpdateOperation(),
    };
}
