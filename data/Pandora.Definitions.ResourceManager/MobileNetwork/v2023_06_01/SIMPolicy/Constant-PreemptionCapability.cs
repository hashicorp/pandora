using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIMPolicy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PreemptionCapabilityConstant
{
    [Description("MayPreempt")]
    MayPreempt,

    [Description("NotPreempt")]
    NotPreempt,
}
