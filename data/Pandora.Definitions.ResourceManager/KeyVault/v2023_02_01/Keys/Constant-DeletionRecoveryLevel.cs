using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.Keys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeletionRecoveryLevelConstant
{
    [Description("Purgeable")]
    Purgeable,

    [Description("Recoverable")]
    Recoverable,

    [Description("Recoverable+ProtectedSubscription")]
    RecoverablePositiveProtectedSubscription,

    [Description("Recoverable+Purgeable")]
    RecoverablePositivePurgeable,
}
