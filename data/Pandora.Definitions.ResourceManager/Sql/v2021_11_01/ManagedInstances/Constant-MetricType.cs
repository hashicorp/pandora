// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetricTypeConstant
{
    [Description("cpu")]
    Cpu,

    [Description("dtu")]
    Dtu,

    [Description("duration")]
    Duration,

    [Description("io")]
    Io,

    [Description("logIo")]
    LogIo,
}
