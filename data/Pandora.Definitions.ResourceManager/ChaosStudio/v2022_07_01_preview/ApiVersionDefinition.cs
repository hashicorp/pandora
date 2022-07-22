using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-07-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Capabilities.Definition(),
        new CapabilityTypes.Definition(),
        new Experiments.Definition(),
        new TargetTypes.Definition(),
        new Targets.Definition(),
    };
}
