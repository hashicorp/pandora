using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-09-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AppPlatform.Definition(),
    };
}
