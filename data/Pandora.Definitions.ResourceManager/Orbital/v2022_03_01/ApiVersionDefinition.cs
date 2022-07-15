using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Contact.Definition(),
        new ContactProfile.Definition(),
        new GroundStation.Definition(),
        new Spacecraft.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
