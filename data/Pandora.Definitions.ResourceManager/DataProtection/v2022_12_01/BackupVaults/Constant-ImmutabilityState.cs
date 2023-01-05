using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImmutabilityStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
