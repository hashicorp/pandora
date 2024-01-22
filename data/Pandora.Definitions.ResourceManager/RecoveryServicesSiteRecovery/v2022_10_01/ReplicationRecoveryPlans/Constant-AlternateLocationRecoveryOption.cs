// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlternateLocationRecoveryOptionConstant
{
    [Description("CreateVmIfNotFound")]
    CreateVMIfNotFound,

    [Description("NoAction")]
    NoAction,
}
