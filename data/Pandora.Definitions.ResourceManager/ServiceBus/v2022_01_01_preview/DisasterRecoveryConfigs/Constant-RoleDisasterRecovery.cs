// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.DisasterRecoveryConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleDisasterRecoveryConstant
{
    [Description("Primary")]
    Primary,

    [Description("PrimaryNotReplicating")]
    PrimaryNotReplicating,

    [Description("Secondary")]
    Secondary,
}
