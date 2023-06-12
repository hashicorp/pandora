using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2023_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ServerVulnerabilityAssessmentsSettings.Definition(),
    };
}
