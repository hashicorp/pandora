// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_08_01.RecoveryServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VaultSubResourceTypeConstant
{
    [Description("AzureBackup")]
    AzureBackup,

    [Description("AzureBackup_secondary")]
    AzureBackupSecondary,

    [Description("AzureSiteRecovery")]
    AzureSiteRecovery,
}
