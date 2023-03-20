using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-06-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AgentPools.Definition(),
        new Registries.Definition(),
        new Runs.Definition(),
        new TaskRuns.Definition(),
        new Tasks.Definition(),
    };
}
