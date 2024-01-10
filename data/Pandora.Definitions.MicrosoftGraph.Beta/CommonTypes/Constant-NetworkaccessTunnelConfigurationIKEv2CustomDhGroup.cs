// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessTunnelConfigurationIKEv2CustomDhGroupConstant
{
    [Description("DhGroup14")]
    @dhGroup14,

    [Description("DhGroup24")]
    @dhGroup24,

    [Description("DhGroup2048")]
    @dhGroup2048,

    [Description("Ecp256")]
    @ecp256,

    [Description("Ecp384")]
    @ecp384,
}
