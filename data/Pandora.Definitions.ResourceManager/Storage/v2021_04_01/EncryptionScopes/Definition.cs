using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.EncryptionScopes;

internal class Definition : ResourceDefinition
{
    public string Name => "EncryptionScopes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new PatchOperation(),
        new PutOperation(),
    };
}
