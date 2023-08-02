// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WiFiSecurityTypeConstant
{
    [Description("Open")]
    @open,

    [Description("WpaPersonal")]
    @wpaPersonal,

    [Description("WpaEnterprise")]
    @wpaEnterprise,

    [Description("Wep")]
    @wep,

    [Description("Wpa2Personal")]
    @wpa2Personal,

    [Description("Wpa2Enterprise")]
    @wpa2Enterprise,
}
