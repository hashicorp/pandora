using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_11_20;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-11-20";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new WorkbookTemplatesAPIS.Definition(),
    };
}
