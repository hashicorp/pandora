using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMs;

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
