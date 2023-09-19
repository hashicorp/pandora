// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum X509CertificateRuleX509CertificateAuthenticationModeConstant
{
    [Description("X509CertificateSingleFactor")]
    @x509CertificateSingleFactor,

    [Description("X509CertificateMultiFactor")]
    @x509CertificateMultiFactor,
}
