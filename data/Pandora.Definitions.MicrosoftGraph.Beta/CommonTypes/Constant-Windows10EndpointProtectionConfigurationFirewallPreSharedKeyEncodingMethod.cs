// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationFirewallPreSharedKeyEncodingMethodConstant
{
    [Description("DeviceDefault")]
    @deviceDefault,

    [Description("None")]
    @none,

    [Description("UtF8")]
    @utF8,
}
