using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DurabilityLevelConstant
{
    [Description("Bronze")]
    Bronze,

    [Description("Gold")]
    Gold,

    [Description("Silver")]
    Silver,
}
