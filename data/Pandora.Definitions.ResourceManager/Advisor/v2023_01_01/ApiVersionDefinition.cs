using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Advisor.v2023_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AdvisorScore.Definition(),
        new Configurations.Definition(),
        new GenerateRecommendations.Definition(),
        new GetRecommendations.Definition(),
        new Metadata.Definition(),
        new Prediction.Definition(),
        new Suppressions.Definition(),
    };
}
