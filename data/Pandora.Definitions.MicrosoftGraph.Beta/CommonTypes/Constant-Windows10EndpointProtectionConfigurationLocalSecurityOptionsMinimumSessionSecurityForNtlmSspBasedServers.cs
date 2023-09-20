// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationLocalSecurityOptionsMinimumSessionSecurityForNtlmSspBasedServersConstant
{
    [Description("None")]
    @none,

    [Description("RequireNtmlV2SessionSecurity")]
    @requireNtmlV2SessionSecurity,

    [Description("Require128BitEncryption")]
    @require128BitEncryption,

    [Description("NtlmV2And128BitEncryption")]
    @ntlmV2And128BitEncryption,
}
