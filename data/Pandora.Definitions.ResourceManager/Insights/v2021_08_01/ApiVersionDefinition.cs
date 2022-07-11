using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ScheduledQueryRules.Definition(),
    };
}
