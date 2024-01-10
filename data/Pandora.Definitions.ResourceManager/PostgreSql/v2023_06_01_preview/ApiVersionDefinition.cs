using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-06-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Administrators.Definition(),
        new AdvancedThreatProtectionSettings.Definition(),
        new Backups.Definition(),
        new CheckNameAvailability.Definition(),
        new Configurations.Definition(),
        new CustomOperation.Definition(),
        new Databases.Definition(),
        new FirewallRules.Definition(),
        new FlexibleServerCapabilities.Definition(),
        new GetPrivateDnsZoneSuffix.Definition(),
        new LocationBasedCapabilities.Definition(),
        new LogFiles.Definition(),
        new LongTermRetentionBackup.Definition(),
        new Migrations.Definition(),
        new POST.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new QuotaUsagesForFlexibleServers.Definition(),
        new Replicas.Definition(),
        new ServerRestart.Definition(),
        new ServerStart.Definition(),
        new ServerStop.Definition(),
        new Servers.Definition(),
        new VirtualEndpoints.Definition(),
    };
}
