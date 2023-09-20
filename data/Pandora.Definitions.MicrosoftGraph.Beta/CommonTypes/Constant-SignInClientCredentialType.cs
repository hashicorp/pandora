// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignInClientCredentialTypeConstant
{
    [Description("None")]
    @none,

    [Description("ClientSecret")]
    @clientSecret,

    [Description("ClientAssertion")]
    @clientAssertion,

    [Description("FederatedIdentityCredential")]
    @federatedIdentityCredential,

    [Description("ManagedIdentity")]
    @managedIdentity,

    [Description("Certificate")]
    @certificate,
}
