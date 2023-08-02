// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RatingUnitedKingdomMoviesTypeConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("General")]
    @general,

    [Description("UniversalChildren")]
    @universalChildren,

    [Description("ParentalGuidance")]
    @parentalGuidance,

    [Description("AgesAbove12Video")]
    @agesAbove12Video,

    [Description("AgesAbove12Cinema")]
    @agesAbove12Cinema,

    [Description("AgesAbove15")]
    @agesAbove15,

    [Description("Adults")]
    @adults,
}
