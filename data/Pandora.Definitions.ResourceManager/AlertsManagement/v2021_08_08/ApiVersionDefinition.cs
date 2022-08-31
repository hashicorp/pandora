using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-08";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AlertProcessingRules.Definition(),
    };
}
