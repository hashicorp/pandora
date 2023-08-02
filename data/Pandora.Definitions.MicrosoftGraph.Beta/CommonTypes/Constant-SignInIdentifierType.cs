// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignInIdentifierTypeConstant
{
    [Description("UserPrincipalName")]
    @userPrincipalName,

    [Description("PhoneNumber")]
    @phoneNumber,

    [Description("ProxyAddress")]
    @proxyAddress,

    [Description("QrCode")]
    @qrCode,

    [Description("OnPremisesUserPrincipalName")]
    @onPremisesUserPrincipalName,
}
