// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosikEv2VpnConfigurationDeadPeerDetectionRateConstant
{
    [Description("Medium")]
    @medium,

    [Description("None")]
    @none,

    [Description("Low")]
    @low,

    [Description("High")]
    @high,
}
