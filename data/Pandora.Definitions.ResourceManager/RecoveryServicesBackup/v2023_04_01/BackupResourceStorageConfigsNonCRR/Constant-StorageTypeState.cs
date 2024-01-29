// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupResourceStorageConfigsNonCRR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeStateConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
