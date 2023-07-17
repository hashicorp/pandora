using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-27";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Monitors.Definition(),
        new SingleSignOn.Definition(),
        new TagRules.Definition(),
    };
}
