using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2018_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Advisors.Definition(),
        new LocationBasedRecommendedActionSessionsResult.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new QueryTexts.Definition(),
        new RecommendedActionSessions.Definition(),
        new RecommendedActions.Definition(),
        new ResetQueryPerformanceInsightData.Definition(),
        new TopQueryStatistics.Definition(),
        new WaitStatistics.Definition(),
    };
}
