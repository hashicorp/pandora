using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-05-05-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ActionRules.Definition(),
        new AlertsManagements.Definition(),
        new SmartGroups.Definition(),
    };
}
