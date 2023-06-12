using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_04_01.VaultUsages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsagesUnitConstant
{
    [Description("Bytes")]
    Bytes,

    [Description("BytesPerSecond")]
    BytesPerSecond,

    [Description("Count")]
    Count,

    [Description("CountPerSecond")]
    CountPerSecond,

    [Description("Percent")]
    Percent,

    [Description("Seconds")]
    Seconds,
}
