// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationProtectionIntents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SetMultiVMSyncStatusConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,
}
