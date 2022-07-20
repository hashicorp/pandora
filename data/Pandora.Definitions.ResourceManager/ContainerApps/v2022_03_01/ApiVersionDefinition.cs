using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

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

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
