// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessDeviceLinkBandwidthCapacityInMbpsConstant
{
    [Description("Mbps250")]
    @mbps250,

    [Description("Mbps500")]
    @mbps500,

    [Description("Mbps750")]
    @mbps750,

    [Description("Mbps1000")]
    @mbps1000,
}
