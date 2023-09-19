// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OnPremisesPublishingSingleSignOnSingleSignOnModeConstant
{
    [Description("None")]
    @none,

    [Description("OnPremisesKerberos")]
    @onPremisesKerberos,

    [Description("Saml")]
    @saml,

    [Description("PingHeaderBased")]
    @pingHeaderBased,

    [Description("AadHeaderBased")]
    @aadHeaderBased,

    [Description("OAuthToken")]
    @oAuthToken,
}
