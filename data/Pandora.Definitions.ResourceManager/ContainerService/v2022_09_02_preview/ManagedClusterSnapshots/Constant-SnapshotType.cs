using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusterSnapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SnapshotTypeConstant
{
    [Description("ManagedCluster")]
    ManagedCluster,

    [Description("NodePool")]
    NodePool,
}
