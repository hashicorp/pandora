// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.BackupResourceEncryptionConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LastUpdateStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("FirstInitialization")]
    FirstInitialization,

    [Description("Initialized")]
    Initialized,

    [Description("Invalid")]
    Invalid,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("PartiallyFailed")]
    PartiallyFailed,

    [Description("PartiallySucceeded")]
    PartiallySucceeded,

    [Description("Succeeded")]
    Succeeded,
}
