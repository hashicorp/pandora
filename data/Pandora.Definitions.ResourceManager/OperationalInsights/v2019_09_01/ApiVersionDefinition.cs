using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2019_09_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-09-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new OperationalInsights.Definition(),
    };
}
