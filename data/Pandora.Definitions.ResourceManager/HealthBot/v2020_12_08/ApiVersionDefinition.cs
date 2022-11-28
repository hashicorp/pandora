using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthBot.v2020_12_08;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-12-08";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Healthbots.Definition(),
    };
}
