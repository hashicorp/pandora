// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MediaContentRatingFranceTvRatingConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("AgesAbove10")]
    @agesAbove10,

    [Description("AgesAbove12")]
    @agesAbove12,

    [Description("AgesAbove16")]
    @agesAbove16,

    [Description("AgesAbove18")]
    @agesAbove18,
}
