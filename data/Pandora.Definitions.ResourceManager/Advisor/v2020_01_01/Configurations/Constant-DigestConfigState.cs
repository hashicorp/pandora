using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DigestConfigStateConstant
{
    [Description("Active")]
    Active,

    [Description("Disabled")]
    Disabled,
}
