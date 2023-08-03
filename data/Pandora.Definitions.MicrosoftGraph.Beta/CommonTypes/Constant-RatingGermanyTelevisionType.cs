// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RatingGermanyTelevisionTypeConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("General")]
    @general,

    [Description("AgesAbove6")]
    @agesAbove6,

    [Description("AgesAbove12")]
    @agesAbove12,

    [Description("AgesAbove16")]
    @agesAbove16,

    [Description("Adults")]
    @adults,
}
