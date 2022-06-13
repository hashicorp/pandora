using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2022_05_13;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-05-13";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ConfidentialLedger.Definition(),
        new NameAvailability.Definition(),
    };
}
