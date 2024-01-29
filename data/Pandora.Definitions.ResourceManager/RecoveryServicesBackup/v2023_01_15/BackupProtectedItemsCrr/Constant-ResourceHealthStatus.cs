// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.BackupProtectedItemsCrr;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceHealthStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("Invalid")]
    Invalid,

    [Description("PersistentDegraded")]
    PersistentDegraded,

    [Description("PersistentUnhealthy")]
    PersistentUnhealthy,

    [Description("TransientDegraded")]
    TransientDegraded,

    [Description("TransientUnhealthy")]
    TransientUnhealthy,
}
