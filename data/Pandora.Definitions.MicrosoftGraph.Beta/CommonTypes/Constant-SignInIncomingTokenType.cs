// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignInIncomingTokenTypeConstant
{
    [Description("None")]
    @none,

    [Description("PrimaryRefreshToken")]
    @primaryRefreshToken,

    [Description("Saml11")]
    @saml11,

    [Description("Saml20")]
    @saml20,

    [Description("RemoteDesktopToken")]
    @remoteDesktopToken,
}
