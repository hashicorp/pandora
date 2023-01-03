using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-07-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ApplyUpdate.Definition(),
        new ApplyUpdates.Definition(),
        new ConfigurationAssignments.Definition(),
        new MaintenanceConfigurations.Definition(),
        new PublicMaintenanceConfigurations.Definition(),
        new Updates.Definition(),
    };
}
