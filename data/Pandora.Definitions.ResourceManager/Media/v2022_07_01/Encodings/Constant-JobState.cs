// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Canceling")]
    Canceling,

    [Description("Error")]
    Error,

    [Description("Finished")]
    Finished,

    [Description("Processing")]
    Processing,

    [Description("Queued")]
    Queued,

    [Description("Scheduled")]
    Scheduled,
}
