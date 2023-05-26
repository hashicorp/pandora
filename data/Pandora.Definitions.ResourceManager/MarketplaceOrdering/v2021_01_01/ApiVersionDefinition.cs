using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MarketplaceOrdering.v2021_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Agreements.Definition(),
    };
}
