// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum X509CertificateRuleX509CertificateRuleTypeConstant
{
    [Description("IssuerSubject")]
    @issuerSubject,

    [Description("PolicyOID")]
    @policyOID,

    [Description("IssuerSubjectAndPolicyOID")]
    @issuerSubjectAndPolicyOID,
}
