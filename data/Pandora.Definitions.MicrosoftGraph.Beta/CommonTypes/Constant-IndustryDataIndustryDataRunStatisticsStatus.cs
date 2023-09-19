// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IndustryDataIndustryDataRunStatisticsStatusConstant
{
    [Description("Running")]
    @running,

    [Description("Failed")]
    @failed,

    [Description("Completed")]
    @completed,

    [Description("CompletedWithErrors")]
    @completedWithErrors,

    [Description("CompletedWithWarnings")]
    @completedWithWarnings,
}
