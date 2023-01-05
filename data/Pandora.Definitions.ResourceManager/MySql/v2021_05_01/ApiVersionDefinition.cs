using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Backups.Definition(),
        new CheckNameAvailability.Definition(),
        new Configurations.Definition(),
        new Databases.Definition(),
        new FirewallRules.Definition(),
        new GetPrivateDnsZoneSuffix.Definition(),
        new LocationBasedCapabilities.Definition(),
        new ServerFailover.Definition(),
        new ServerRestart.Definition(),
        new ServerStart.Definition(),
        new ServerStop.Definition(),
        new Servers.Definition(),
    };
}
