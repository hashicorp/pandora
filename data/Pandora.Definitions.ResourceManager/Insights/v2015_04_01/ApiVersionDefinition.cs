using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2015-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ActivityLogs.Definition(),
        new AutoScaleSettings.Definition(),
        new AutoscaleAPIs.Definition(),
        new EventCategories.Definition(),
        new TenantActivityLogs.Definition(),
    };
}
