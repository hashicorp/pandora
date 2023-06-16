using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.CapacityPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceLevelConstant
{
    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,

    [Description("StandardZRS")]
    StandardZRS,

    [Description("Ultra")]
    Ultra,
}
