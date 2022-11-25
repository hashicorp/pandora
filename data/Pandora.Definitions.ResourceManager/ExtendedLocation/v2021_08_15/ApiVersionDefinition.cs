using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ExtendedLocation.v2021_08_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CustomLocations.Definition(),
    };
}
