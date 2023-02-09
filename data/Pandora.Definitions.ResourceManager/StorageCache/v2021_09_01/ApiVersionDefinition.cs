using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-09-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Caches.Definition(),
        new SKUs.Definition(),
        new StorageTargets.Definition(),
        new UsageModels.Definition(),
    };
}
