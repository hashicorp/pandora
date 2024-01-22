// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.UpdateRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("NotStarted")]
    NotStarted,

    [Description("Running")]
    Running,

    [Description("Skipped")]
    Skipped,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,
}
