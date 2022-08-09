using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Advisors.Definition(),
        new CheckNameAvailability.Definition(),
        new Configurations.Definition(),
        new ConfigurationsUpdate.Definition(),
        new Databases.Definition(),
        new FirewallRules.Definition(),
        new LocationBasedPerformanceTier.Definition(),
        new LocationBasedRecommendedActionSessionsResult.Definition(),
        new LogFiles.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new QueryTexts.Definition(),
        new RecommendedActionSessions.Definition(),
        new RecommendedActions.Definition(),
        new RecoverableServers.Definition(),
        new Replicas.Definition(),
        new ResetQueryPerformanceInsightData.Definition(),
        new ServerBasedPerformanceTier.Definition(),
        new ServerRestart.Definition(),
        new ServerSecurityAlertPolicies.Definition(),
        new Servers.Definition(),
        new TopQueryStatistics.Definition(),
        new VirtualNetworkRules.Definition(),
        new WaitStatistics.Definition(),
    };
}
