using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2018_10_31_preview;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-10-31-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DedicatedHsms.Definition(),
    };
}
