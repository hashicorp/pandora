using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Endpoints.Definition(),
        new GeographicHierarchies.Definition(),
        new HeatMaps.Definition(),
        new Profiles.Definition(),
        new RealUserMetrics.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
