// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MediaContentRatingCanadaTvRatingConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("Children")]
    @children,

    [Description("ChildrenAbove8")]
    @childrenAbove8,

    [Description("General")]
    @general,

    [Description("ParentalGuidance")]
    @parentalGuidance,

    [Description("AgesAbove14")]
    @agesAbove14,

    [Description("AgesAbove18")]
    @agesAbove18,
}
