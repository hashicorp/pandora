// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsDeliveryOptimizationModeConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("HttpOnly")]
    @httpOnly,

    [Description("HttpWithPeeringNat")]
    @httpWithPeeringNat,

    [Description("HttpWithPeeringPrivateGroup")]
    @httpWithPeeringPrivateGroup,

    [Description("HttpWithInternetPeering")]
    @httpWithInternetPeering,

    [Description("SimpleDownload")]
    @simpleDownload,

    [Description("BypassMode")]
    @bypassMode,
}
