using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.GraphServices.v2023_04_13;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-13";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Graphservicesprods.Definition(),
    };
}
