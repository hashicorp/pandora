using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ControlPlaneUpgradeOverrideConstant
{
    [Description("IgnoreKubernetesDeprecations")]
    IgnoreKubernetesDeprecations,
}
