using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsmKeys;

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
