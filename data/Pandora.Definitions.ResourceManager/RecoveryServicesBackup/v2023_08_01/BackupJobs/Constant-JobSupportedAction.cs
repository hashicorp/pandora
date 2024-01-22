// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupJobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobSupportedActionConstant
{
    [Description("Cancellable")]
    Cancellable,

    [Description("Invalid")]
    Invalid,

    [Description("Retriable")]
    Retriable,
}
