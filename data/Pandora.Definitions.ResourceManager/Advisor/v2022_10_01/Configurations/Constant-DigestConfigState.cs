using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DigestConfigStateConstant
{
    [Description("Active")]
    Active,

    [Description("Disabled")]
    Disabled,
}
