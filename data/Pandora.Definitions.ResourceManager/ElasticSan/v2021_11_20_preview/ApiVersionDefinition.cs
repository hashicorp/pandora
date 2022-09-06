using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-11-20-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ElasticSan.Definition(),
        new ElasticSanSkus.Definition(),
        new ElasticSans.Definition(),
        new VolumeGroups.Definition(),
        new Volumes.Definition(),
    };
}
