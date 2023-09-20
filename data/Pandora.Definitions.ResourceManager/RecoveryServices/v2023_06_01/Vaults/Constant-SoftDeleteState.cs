using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_06_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoftDeleteStateConstant
{
    [Description("AlwaysON")]
    AlwaysON,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Invalid")]
    Invalid,
}
