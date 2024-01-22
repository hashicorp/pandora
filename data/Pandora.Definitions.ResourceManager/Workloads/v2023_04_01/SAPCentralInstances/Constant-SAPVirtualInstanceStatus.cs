// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPCentralInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPVirtualInstanceStatusConstant
{
    [Description("Offline")]
    Offline,

    [Description("PartiallyRunning")]
    PartiallyRunning,

    [Description("Running")]
    Running,

    [Description("SoftShutdown")]
    SoftShutdown,

    [Description("Starting")]
    Starting,

    [Description("Stopping")]
    Stopping,

    [Description("Unavailable")]
    Unavailable,
}
