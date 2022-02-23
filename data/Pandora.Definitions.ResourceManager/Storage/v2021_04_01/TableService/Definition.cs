using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.TableService;

internal class Definition : ResourceDefinition
{
    public string Name => "TableService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TableCreateOperation(),
        new TableDeleteOperation(),
        new TableGetOperation(),
        new TableListOperation(),
        new TableUpdateOperation(),
    };
}
