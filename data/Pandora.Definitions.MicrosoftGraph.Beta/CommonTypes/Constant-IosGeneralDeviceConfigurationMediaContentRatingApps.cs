// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosGeneralDeviceConfigurationMediaContentRatingAppsConstant
{
    [Description("AllAllowed")]
    @allAllowed,

    [Description("AllBlocked")]
    @allBlocked,

    [Description("AgesAbove4")]
    @agesAbove4,

    [Description("AgesAbove9")]
    @agesAbove9,

    [Description("AgesAbove12")]
    @agesAbove12,

    [Description("AgesAbove17")]
    @agesAbove17,
}
