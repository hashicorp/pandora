// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationFabrics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RcmComponentStatusConstant
{
    [Description("Critical")]
    Critical,

    [Description("Healthy")]
    Healthy,

    [Description("Unknown")]
    Unknown,

    [Description("Warning")]
    Warning,
}
