// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.ProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectedItemHealthStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("IRPending")]
    IRPending,

    [Description("Invalid")]
    Invalid,

    [Description("NotReachable")]
    NotReachable,

    [Description("Unhealthy")]
    Unhealthy,
}
