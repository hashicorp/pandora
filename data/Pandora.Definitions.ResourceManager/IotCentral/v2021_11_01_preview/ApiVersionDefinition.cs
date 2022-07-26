using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.IotCentral.v2021_11_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-11-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Apps.Definition(),
        new Networking.Definition(),
    };
}
