using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AutoScaleVCores.Definition(),
        new Capacities.Definition(),
        new PowerBIDedicated.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
