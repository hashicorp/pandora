// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.Operation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryModeConstant
{
    [Description("FileRecovery")]
    FileRecovery,

    [Description("Invalid")]
    Invalid,

    [Description("RecoveryUsingSnapshot")]
    RecoveryUsingSnapshot,

    [Description("SnapshotAttach")]
    SnapshotAttach,

    [Description("SnapshotAttachAndRecover")]
    SnapshotAttachAndRecover,

    [Description("WorkloadRecovery")]
    WorkloadRecovery,
}
