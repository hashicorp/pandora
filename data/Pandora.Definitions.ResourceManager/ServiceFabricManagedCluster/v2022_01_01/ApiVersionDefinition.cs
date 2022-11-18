using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Application.Definition(),
        new ApplicationType.Definition(),
        new ApplicationTypeVersion.Definition(),
        new ManagedCluster.Definition(),
        new ManagedClusterVersion.Definition(),
        new ManagedVMSizes.Definition(),
        new NodeType.Definition(),
        new Service.Definition(),
        new Services.Definition(),
    };
}
