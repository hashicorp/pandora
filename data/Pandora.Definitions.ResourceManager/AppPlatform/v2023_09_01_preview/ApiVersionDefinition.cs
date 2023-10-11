using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_09_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-09-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AppPlatform.Definition(),
    };
}
