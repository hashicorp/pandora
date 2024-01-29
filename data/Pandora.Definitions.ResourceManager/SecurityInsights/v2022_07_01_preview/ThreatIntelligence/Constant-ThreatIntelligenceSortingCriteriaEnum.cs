// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.ThreatIntelligence;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThreatIntelligenceSortingCriteriaEnumConstant
{
    [Description("ascending")]
    Ascending,

    [Description("descending")]
    Descending,

    [Description("unsorted")]
    Unsorted,
}
