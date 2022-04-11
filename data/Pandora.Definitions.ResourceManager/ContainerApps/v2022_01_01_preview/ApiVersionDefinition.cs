using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-01-01-preview";
    public bool Preview => true;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Certificates.Definition(),
        new ContainerApps.Definition(),
        new ContainerAppsAuthConfigs.Definition(),
        new ContainerAppsRevisionReplicas.Definition(),
        new ContainerAppsRevisions.Definition(),
        new ContainerAppsSourceControls.Definition(),
        new DaprComponents.Definition(),
        new ManagedEnvironments.Definition(),
        new ManagedEnvironmentsStorages.Definition(),
    };
}
