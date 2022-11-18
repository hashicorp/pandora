using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-06-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new WebTestsAPIs.Definition(),
    };
}
