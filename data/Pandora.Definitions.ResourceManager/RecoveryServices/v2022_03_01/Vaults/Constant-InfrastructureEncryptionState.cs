using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_03_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InfrastructureEncryptionStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
