// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationStrengthPolicyAllowedCombinationsConstant
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

    [Description("MicrosoftAuthenticatorPush")]
    @microsoftAuthenticatorPush,

    [Description("DeviceBasedPush")]
    @deviceBasedPush,

    [Description("TemporaryAccessPassOneTime")]
    @temporaryAccessPassOneTime,

    [Description("TemporaryAccessPassMultiUse")]
    @temporaryAccessPassMultiUse,

    [Description("Email")]
    @email,

    [Description("X509CertificateSingleFactor")]
    @x509CertificateSingleFactor,

    [Description("X509CertificateMultiFactor")]
    @x509CertificateMultiFactor,

    [Description("FederatedSingleFactor")]
    @federatedSingleFactor,

    [Description("FederatedMultiFactor")]
    @federatedMultiFactor,
}
