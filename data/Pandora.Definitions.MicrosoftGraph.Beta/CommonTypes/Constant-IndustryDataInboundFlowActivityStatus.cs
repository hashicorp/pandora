// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IndustryDataInboundFlowActivityStatusConstant
{
    [Description("InProgress")]
    @inProgress,

    [Description("Skipped")]
    @skipped,

    [Description("Failed")]
    @failed,

    [Description("Completed")]
    @completed,

    [Description("CompletedWithErrors")]
    @completedWithErrors,

    [Description("CompletedWithWarnings")]
    @completedWithWarnings,
}
