using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2017-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckNameAvailability.Definition(),
        new Configurations.Definition(),
        new ConfigurationsUpdate.Definition(),
        new Databases.Definition(),
        new FirewallRules.Definition(),
        new LocationBasedPerformanceTier.Definition(),
        new LogFiles.Definition(),
        new RecoverableServers.Definition(),
        new Replicas.Definition(),
        new ServerAdministrators.Definition(),
        new ServerBasedPerformanceTier.Definition(),
        new ServerRestart.Definition(),
        new ServerSecurityAlertPolicies.Definition(),
        new Servers.Definition(),
        new VirtualNetworkRules.Definition(),
    };
}
