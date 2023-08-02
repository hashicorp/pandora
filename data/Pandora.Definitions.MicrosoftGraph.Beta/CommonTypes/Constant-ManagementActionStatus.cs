// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementActionStatusConstant
{
    [Description("ToAddress")]
    @toAddress,

    [Description("Completed")]
    @completed,

    [Description("Error")]
    @error,

    [Description("TimeOut")]
    @timeOut,

    [Description("InProgress")]
    @inProgress,

    [Description("Planned")]
    @planned,

    [Description("ResolvedBy3rdParty")]
    @resolvedBy3rdParty,

    [Description("ResolvedThroughAlternateMitigation")]
    @resolvedThroughAlternateMitigation,

    [Description("RiskAccepted")]
    @riskAccepted,
}
