using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2016-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ConnectionGateways.Definition(),
        new Connections.Definition(),
        new CustomAPIs.Definition(),
        new ManagedAPIs.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
