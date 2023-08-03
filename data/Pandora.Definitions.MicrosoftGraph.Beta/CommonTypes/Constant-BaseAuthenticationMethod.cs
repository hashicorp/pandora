// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BaseAuthenticationMethodConstant
{
    [Description("Password")]
    @password,

    [Description("Voice")]
    @voice,

    [Description("HardwareOath")]
    @hardwareOath,

    [Description("SoftwareOath")]
    @softwareOath,

    [Description("Sms")]
    @sms,

    [Description("Fido2")]
    @fido2,

    [Description("WindowsHelloForBusiness")]
    @windowsHelloForBusiness,

    [Description("MicrosoftAuthenticator")]
    @microsoftAuthenticator,

    [Description("TemporaryAccessPass")]
    @temporaryAccessPass,

    [Description("Email")]
    @email,

    [Description("X509Certificate")]
    @x509Certificate,

    [Description("Federation")]
    @federation,
}
