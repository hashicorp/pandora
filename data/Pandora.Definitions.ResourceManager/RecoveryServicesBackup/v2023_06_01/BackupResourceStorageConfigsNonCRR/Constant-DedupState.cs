// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.BackupResourceStorageConfigsNonCRR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DedupStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Invalid")]
    Invalid,
}
