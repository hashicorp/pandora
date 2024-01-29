// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.BackupProtectableItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFileShareTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("XSMB")]
    XSMB,

    [Description("XSync")]
    XSync,
}
