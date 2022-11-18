using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2020_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new PrivateZones.Definition(),
        new RecordSets.Definition(),
        new VirtualNetworkLinks.Definition(),
    };
}
