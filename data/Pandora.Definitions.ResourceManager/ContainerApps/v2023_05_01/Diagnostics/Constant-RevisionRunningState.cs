// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RevisionRunningStateConstant
{
    [Description("Degraded")]
    Degraded,

    [Description("Failed")]
    Failed,

    [Description("Processing")]
    Processing,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,

    [Description("Unknown")]
    Unknown,
}
