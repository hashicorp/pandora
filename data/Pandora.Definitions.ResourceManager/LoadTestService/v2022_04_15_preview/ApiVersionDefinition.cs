using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_04_15_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-04-15-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new LoadTests.Definition(),
    };
}
