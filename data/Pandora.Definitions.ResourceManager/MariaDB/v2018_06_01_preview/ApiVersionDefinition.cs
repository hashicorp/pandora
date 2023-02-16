using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-06-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckNameAvailability.Definition(),
        new Configurations.Definition(),
        new Databases.Definition(),
        new FirewallRules.Definition(),
        new LocationBasedPerformanceTier.Definition(),
        new LogFiles.Definition(),
        new RecoverableServers.Definition(),
        new Replicas.Definition(),
        new ServerBasedPerformanceTier.Definition(),
        new ServerRestart.Definition(),
        new ServerSecurityAlertPolicies.Definition(),
        new Servers.Definition(),
        new UpdateConfigurations.Definition(),
        new VirtualNetworkRules.Definition(),
    };
}
