using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new LoadTest.Definition(),
        new LoadTests.Definition(),
        new Quotas.Definition(),
    };
}
