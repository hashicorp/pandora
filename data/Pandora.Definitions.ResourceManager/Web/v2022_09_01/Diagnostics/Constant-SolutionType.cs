// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SolutionTypeConstant
{
    [Description("BestPractices")]
    BestPractices,

    [Description("DeepInvestigation")]
    DeepInvestigation,

    [Description("QuickSolution")]
    QuickSolution,
}
