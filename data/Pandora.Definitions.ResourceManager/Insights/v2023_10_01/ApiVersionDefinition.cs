using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new MetricDefinitions.Definition(),
        new Metrics.Definition(),
    };
}
