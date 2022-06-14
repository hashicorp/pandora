using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_05_26;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-05-26";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new FluidRelayContainers.Definition(),
        new FluidRelayServers.Definition(),
    };
}
