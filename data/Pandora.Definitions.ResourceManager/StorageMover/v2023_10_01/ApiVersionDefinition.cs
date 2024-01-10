using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Agents.Definition(),
        new Endpoints.Definition(),
        new JobDefinitions.Definition(),
        new JobRuns.Definition(),
        new Projects.Definition(),
        new StorageMovers.Definition(),
    };
}
