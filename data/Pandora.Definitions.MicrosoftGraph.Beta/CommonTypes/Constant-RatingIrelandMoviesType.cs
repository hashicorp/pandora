// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RatingIrelandMoviesTypeConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("General")]
    @general,

    [Description("ParentalGuidance")]
    @parentalGuidance,

    [Description("AgesAbove12")]
    @agesAbove12,

    [Description("AgesAbove15")]
    @agesAbove15,

    [Description("AgesAbove16")]
    @agesAbove16,

    [Description("Adults")]
    @adults,
}
