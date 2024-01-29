// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStatusConstant
{
    [Description("CancelRequested")]
    CancelRequested,

    [Description("Canceled")]
    Canceled,

    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Finalizing")]
    Finalizing,

    [Description("NotResponding")]
    NotResponding,

    [Description("NotStarted")]
    NotStarted,

    [Description("Paused")]
    Paused,

    [Description("Preparing")]
    Preparing,

    [Description("Provisioning")]
    Provisioning,

    [Description("Queued")]
    Queued,

    [Description("Running")]
    Running,

    [Description("Scheduled")]
    Scheduled,

    [Description("Starting")]
    Starting,

    [Description("Unknown")]
    Unknown,
}
