// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessTunnelConfigurationIKEv2CustomIpSecIntegrityConstant
{
    [Description("GcmAes128")]
    @gcmAes128,

    [Description("GcmAes192")]
    @gcmAes192,

    [Description("GcmAes256")]
    @gcmAes256,

    [Description("Sha256")]
    @sha256,
}
