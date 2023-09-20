// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserExperienceAnalyticsAnomalySeverityConstant
{
    [Description("High")]
    @high,

    [Description("Medium")]
    @medium,

    [Description("Low")]
    @low,

    [Description("Informational")]
    @informational,

    [Description("Other")]
    @other,
}
