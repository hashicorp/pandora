// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessTunnelConfigurationIKEv2CustomIkeEncryptionConstant
{
    [Description("Aes128")]
    @aes128,

    [Description("Aes192")]
    @aes192,

    [Description("Aes256")]
    @aes256,

    [Description("GcmAes128")]
    @gcmAes128,

    [Description("GcmAes256")]
    @gcmAes256,
}
