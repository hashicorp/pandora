// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSDeviceFeaturesConfigurationContentCachingClientPolicyConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("ClientsInLocalNetwork")]
    @clientsInLocalNetwork,

    [Description("ClientsWithSamePublicIpAddress")]
    @clientsWithSamePublicIpAddress,

    [Description("ClientsInCustomLocalNetworks")]
    @clientsInCustomLocalNetworks,

    [Description("ClientsInCustomLocalNetworksWithFallback")]
    @clientsInCustomLocalNetworksWithFallback,
}
