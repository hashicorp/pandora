// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.SensitivityLabels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitivityLabelRankConstant
{
    [Description("Critical")]
    Critical,

    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,

    [Description("None")]
    None,
}
