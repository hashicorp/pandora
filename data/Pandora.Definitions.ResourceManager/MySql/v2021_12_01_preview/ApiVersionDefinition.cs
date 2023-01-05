using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-12-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AzureADAdministrators.Definition(),
        new Backups.Definition(),
        new CheckNameAvailability.Definition(),
        new Configurations.Definition(),
        new Databases.Definition(),
        new FirewallRules.Definition(),
        new GetPrivateDnsZoneSuffix.Definition(),
        new LocationBasedCapabilities.Definition(),
        new LogFiles.Definition(),
        new ServerFailover.Definition(),
        new ServerRestart.Definition(),
        new ServerStart.Definition(),
        new ServerStop.Definition(),
        new Servers.Definition(),
    };
}
