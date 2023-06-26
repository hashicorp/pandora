using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_04_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MultiUserAuthorizationConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Invalid")]
    Invalid,
}
