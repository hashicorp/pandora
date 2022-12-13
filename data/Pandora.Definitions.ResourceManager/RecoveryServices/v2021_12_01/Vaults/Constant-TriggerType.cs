using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_12_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerTypeConstant
{
    [Description("ForcedUpgrade")]
    ForcedUpgrade,

    [Description("UserTriggered")]
    UserTriggered,
}
