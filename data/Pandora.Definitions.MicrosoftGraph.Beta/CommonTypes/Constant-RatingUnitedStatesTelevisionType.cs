// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RatingUnitedStatesTelevisionTypeConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("ChildrenAll")]
    @childrenAll,

    [Description("ChildrenAbove7")]
    @childrenAbove7,

    [Description("General")]
    @general,

    [Description("ParentalGuidance")]
    @parentalGuidance,

    [Description("ChildrenAbove14")]
    @childrenAbove14,

    [Description("Adults")]
    @adults,
}
