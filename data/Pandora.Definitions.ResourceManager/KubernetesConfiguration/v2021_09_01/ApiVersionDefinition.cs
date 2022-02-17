using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-09-01";
    public bool Preview => false;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ClusterExtensions.Definition(),
        new Extensions.Definition(),
        new OperationStatus.Definition(),
        new OperationsInACluster.Definition(),
    };
}
