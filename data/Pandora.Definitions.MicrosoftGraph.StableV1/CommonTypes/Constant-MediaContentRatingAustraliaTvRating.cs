// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MediaContentRatingAustraliaTvRatingConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("Preschoolers")]
    @preschoolers,

    [Description("Children")]
    @children,

    [Description("General")]
    @general,

    [Description("ParentalGuidance")]
    @parentalGuidance,

    [Description("Mature")]
    @mature,

    [Description("AgesAbove15")]
    @agesAbove15,

    [Description("AgesAbove15AdultViolence")]
    @agesAbove15AdultViolence,
}
