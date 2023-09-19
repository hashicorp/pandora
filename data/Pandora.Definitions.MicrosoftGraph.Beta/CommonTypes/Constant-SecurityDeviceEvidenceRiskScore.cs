// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityDeviceEvidenceRiskScoreConstant
{
    [Description("None")]
    @none,

    [Description("Informational")]
    @informational,

    [Description("Low")]
    @low,

    [Description("Medium")]
    @medium,

    [Description("High")]
    @high,
}
