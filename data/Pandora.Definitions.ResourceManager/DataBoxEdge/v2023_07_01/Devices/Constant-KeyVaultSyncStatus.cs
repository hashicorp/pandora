// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Devices;

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
