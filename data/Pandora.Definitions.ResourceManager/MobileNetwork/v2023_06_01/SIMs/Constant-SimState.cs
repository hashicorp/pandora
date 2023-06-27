using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SimStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Invalid")]
    Invalid,
}
