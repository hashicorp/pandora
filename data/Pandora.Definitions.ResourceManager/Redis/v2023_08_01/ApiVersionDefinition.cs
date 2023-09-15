using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AAD.Definition(),
        new FirewallRules.Definition(),
        new PatchSchedules.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Redis.Definition(),
    };
}
