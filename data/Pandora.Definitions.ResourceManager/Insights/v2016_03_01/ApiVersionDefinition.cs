using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2016-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AlertRuleIncidents.Definition(),
        new AlertRules.Definition(),
        new AlertRulesAPIs.Definition(),
        new LogProfiles.Definition(),
        new LogProfilesAPIs.Definition(),
        new MetricDefinitions.Definition(),
    };
}
