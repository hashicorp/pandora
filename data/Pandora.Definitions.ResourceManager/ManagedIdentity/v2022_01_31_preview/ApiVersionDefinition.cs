using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2022_01_31_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-01-31-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ManagedIdentities.Definition(),
    };
}
