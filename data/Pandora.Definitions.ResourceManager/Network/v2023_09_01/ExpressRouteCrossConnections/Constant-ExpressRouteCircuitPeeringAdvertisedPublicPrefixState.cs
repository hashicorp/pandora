// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCrossConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant
{
    [Description("Configured")]
    Configured,

    [Description("Configuring")]
    Configuring,

    [Description("NotConfigured")]
    NotConfigured,

    [Description("ValidationNeeded")]
    ValidationNeeded,
}
