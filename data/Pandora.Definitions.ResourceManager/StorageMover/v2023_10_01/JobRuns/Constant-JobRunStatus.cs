// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_10_01.JobRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobRunStatusConstant
{
    [Description("CancelRequested")]
    CancelRequested,

    [Description("Canceled")]
    Canceled,

    [Description("Canceling")]
    Canceling,

    [Description("Failed")]
    Failed,

    [Description("Queued")]
    Queued,

    [Description("Running")]
    Running,

    [Description("Started")]
    Started,

    [Description("Succeeded")]
    Succeeded,
}
