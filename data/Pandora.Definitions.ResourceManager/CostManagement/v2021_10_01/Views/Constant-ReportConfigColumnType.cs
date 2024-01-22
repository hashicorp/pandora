// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReportConfigColumnTypeConstant
{
    [Description("Dimension")]
    Dimension,

    [Description("Tag")]
    Tag,
}
