using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ArcSettings.Definition(),
        new Cluster.Definition(),
        new Clusters.Definition(),
        new Extensions.Definition(),
        new Offers.Definition(),
        new Publishers.Definition(),
        new Skuses.Definition(),
        new UpdateRuns.Definition(),
        new UpdateSummaries.Definition(),
        new Updates.Definition(),
    };
}
