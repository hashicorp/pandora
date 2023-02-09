using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-05-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AccessPolicies.Definition(),
        new Environments.Definition(),
        new EventSources.Definition(),
        new ReferenceDataSets.Definition(),
    };
}
