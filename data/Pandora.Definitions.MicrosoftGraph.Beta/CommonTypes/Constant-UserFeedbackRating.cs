// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserFeedbackRatingConstant
{
    [Description("NotRated")]
    @notRated,

    [Description("Bad")]
    @bad,

    [Description("Poor")]
    @poor,

    [Description("Fair")]
    @fair,

    [Description("Good")]
    @good,

    [Description("Excellent")]
    @excellent,
}
