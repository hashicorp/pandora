// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.ProtectionIntent;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectionIntentItemTypeConstant
{
    [Description("AzureResourceItem")]
    AzureResourceItem,

    [Description("AzureWorkloadAutoProtectionIntent")]
    AzureWorkloadAutoProtectionIntent,

    [Description("AzureWorkloadContainerAutoProtectionIntent")]
    AzureWorkloadContainerAutoProtectionIntent,

    [Description("AzureWorkloadSQLAutoProtectionIntent")]
    AzureWorkloadSQLAutoProtectionIntent,

    [Description("Invalid")]
    Invalid,

    [Description("RecoveryServiceVaultItem")]
    RecoveryServiceVaultItem,
}
