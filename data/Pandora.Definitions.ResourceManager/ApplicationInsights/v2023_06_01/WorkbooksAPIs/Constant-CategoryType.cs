// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2023_06_01.WorkbooksAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryTypeConstant
{
    [Description("performance")]
    Performance,

    [Description("retention")]
    Retention,

    [Description("TSG")]
    TSG,

    [Description("workbook")]
    Workbook,
}
