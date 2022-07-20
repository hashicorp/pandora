using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2017-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new HybridConnections.Definition(),
        new Namespaces.Definition(),
        new WCFRelays.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
