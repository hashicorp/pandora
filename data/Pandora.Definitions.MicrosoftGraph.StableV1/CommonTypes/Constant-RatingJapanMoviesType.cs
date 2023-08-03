// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RatingJapanMoviesTypeConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("General")]
    @general,

    [Description("ParentalGuidance")]
    @parentalGuidance,

    [Description("AgesAbove15")]
    @agesAbove15,

    [Description("AgesAbove18")]
    @agesAbove18,
}
