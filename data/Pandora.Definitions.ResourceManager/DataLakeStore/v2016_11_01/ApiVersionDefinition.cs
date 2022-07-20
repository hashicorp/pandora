using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2016-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Accounts.Definition(),
        new FirewallRules.Definition(),
        new Locations.Definition(),
        new TrustedIdProviders.Definition(),
        new VirtualNetworkRules.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
