using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;

internal class Definition : ResourceDefinition
{
    public string Name => "Connections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConfirmConsentCodeOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListConsentLinksOperation(),
        new UpdateOperation(),
    };
}
