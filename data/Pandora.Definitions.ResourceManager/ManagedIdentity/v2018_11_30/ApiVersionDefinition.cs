using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-11-30";
    public bool Preview => false;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ManagedIdentity.Definition(),
    };
}
