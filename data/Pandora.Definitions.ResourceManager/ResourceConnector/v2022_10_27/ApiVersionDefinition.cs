using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-10-27";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Appliances.Definition(),
    };
}
