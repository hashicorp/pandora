using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-05-13-preview";
    public bool Preview => true;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ConfidentialLedger.Definition(),
        new NameAvailability.Definition(),
    };
}
