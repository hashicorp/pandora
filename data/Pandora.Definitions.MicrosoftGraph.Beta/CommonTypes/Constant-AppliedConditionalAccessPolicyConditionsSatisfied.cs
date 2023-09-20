// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppliedConditionalAccessPolicyConditionsSatisfiedConstant
{
    [Description("None")]
    @none,

    [Description("Application")]
    @application,

    [Description("Users")]
    @users,

    [Description("DevicePlatform")]
    @devicePlatform,

    [Description("Location")]
    @location,

    [Description("ClientType")]
    @clientType,

    [Description("SignInRisk")]
    @signInRisk,

    [Description("UserRisk")]
    @userRisk,

    [Description("Time")]
    @time,

    [Description("DeviceState")]
    @deviceState,

    [Description("Client")]
    @client,

    [Description("IpAddressSeenByAzureAD")]
    @ipAddressSeenByAzureAD,

    [Description("IpAddressSeenByResourceProvider")]
    @ipAddressSeenByResourceProvider,

    [Description("ServicePrincipals")]
    @servicePrincipals,

    [Description("ServicePrincipalRisk")]
    @servicePrincipalRisk,

    [Description("AuthenticationFlows")]
    @authenticationFlows,

    [Description("InsiderRisk")]
    @insiderRisk,
}
