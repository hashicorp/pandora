using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Service;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceScalingMechanismKindConstant
{
    [Description("AddRemoveIncrementalNamedPartition")]
    AddRemoveIncrementalNamedPartition,

    [Description("ScalePartitionInstanceCount")]
    ScalePartitionInstanceCount,
}
