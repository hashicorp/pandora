// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionAfterRebootConstant
{
    [Description("ContinueConfiguration")]
    ContinueConfiguration,

    [Description("StopConfiguration")]
    StopConfiguration,
}
