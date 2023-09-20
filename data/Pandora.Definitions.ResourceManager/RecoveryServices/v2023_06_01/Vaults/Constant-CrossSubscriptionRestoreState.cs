using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_06_01.Vaults;

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
