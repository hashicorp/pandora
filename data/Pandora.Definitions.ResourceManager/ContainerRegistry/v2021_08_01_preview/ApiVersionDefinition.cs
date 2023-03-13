using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ConnectedRegistries.Definition(),
        new ExportPipelines.Definition(),
        new ImportPipelines.Definition(),
        new Operation.Definition(),
        new PipelineRuns.Definition(),
        new PrivateEndpointConnections.Definition(),
        new Registries.Definition(),
        new Replications.Definition(),
        new ScopeMaps.Definition(),
        new Tokens.Definition(),
        new WebHooks.Definition(),
    };
}
