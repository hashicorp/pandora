// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityConfigurationTaskEndpointSecurityPolicyConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Antivirus")]
    @antivirus,

    [Description("DiskEncryption")]
    @diskEncryption,

    [Description("Firewall")]
    @firewall,

    [Description("EndpointDetectionAndResponse")]
    @endpointDetectionAndResponse,

    [Description("AttackSurfaceReduction")]
    @attackSurfaceReduction,

    [Description("AccountProtection")]
    @accountProtection,
}
