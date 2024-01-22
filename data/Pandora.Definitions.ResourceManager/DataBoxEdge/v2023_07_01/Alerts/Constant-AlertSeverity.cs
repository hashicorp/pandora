// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertSeverityConstant
{
    [Description("Critical")]
    Critical,

    [Description("Informational")]
    Informational,

    [Description("Warning")]
    Warning,
}
