// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MediaContentRatingIrelandTvRatingConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("General")]
    @general,

    [Description("Children")]
    @children,

    [Description("YoungAdults")]
    @youngAdults,

    [Description("ParentalSupervision")]
    @parentalSupervision,

    [Description("Mature")]
    @mature,
}
