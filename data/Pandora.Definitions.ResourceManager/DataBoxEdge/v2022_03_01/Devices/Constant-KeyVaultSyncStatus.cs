using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyVaultSyncStatusConstant
{
    [Description("KeyVaultNotConfigured")]
    KeyVaultNotConfigured,

    [Description("KeyVaultNotSynced")]
    KeyVaultNotSynced,

    [Description("KeyVaultSyncFailed")]
    KeyVaultSyncFailed,

    [Description("KeyVaultSyncPending")]
    KeyVaultSyncPending,

    [Description("KeyVaultSynced")]
    KeyVaultSynced,

    [Description("KeyVaultSyncing")]
    KeyVaultSyncing,
}
