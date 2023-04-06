using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_01_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CrossSubscriptionRestoreStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("PermanentlyDisabled")]
    PermanentlyDisabled,
}
