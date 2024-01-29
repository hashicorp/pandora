// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReportTypeConstant
{
    [Description("Usage")]
    Usage,
}
