// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPlanGroupTypeConstant
{
    [Description("Boot")]
    Boot,

    [Description("Failover")]
    Failover,

    [Description("Shutdown")]
    Shutdown,
}
