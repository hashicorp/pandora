using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2020_10_05_privatepreview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-10-05-privatepreview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Configurations.Definition(),
        new FirewallRules.Definition(),
        new Roles.Definition(),
        new ServerGroups.Definition(),
        new Servers.Definition(),
    };
}
