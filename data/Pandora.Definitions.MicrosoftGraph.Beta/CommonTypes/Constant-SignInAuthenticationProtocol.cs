// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignInAuthenticationProtocolConstant
{
    [Description("None")]
    @none,

    [Description("OAuth2")]
    @oAuth2,

    [Description("Ropc")]
    @ropc,

    [Description("WsFederation")]
    @wsFederation,

    [Description("Saml20")]
    @saml20,

    [Description("DeviceCode")]
    @deviceCode,

    [Description("AuthenticationTransfer")]
    @authenticationTransfer,
}
