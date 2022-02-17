using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.OperationsInACluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterRpConstant
{
    [Description("Microsoft.ContainerService")]
    MicrosoftPointContainerService,

    [Description("Microsoft.Kubernetes")]
    MicrosoftPointKubernetes,
}
