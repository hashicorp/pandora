using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DNS Resolver.v2022_07_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-07-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DnsForwardingRulesets.Definition(),
        new DnsResolvers.Definition(),
        new ForwardingRules.Definition(),
        new InboundEndpoints.Definition(),
        new OutboundEndpoints.Definition(),
        new VirtualNetworkLinks.Definition(),
    };
}
