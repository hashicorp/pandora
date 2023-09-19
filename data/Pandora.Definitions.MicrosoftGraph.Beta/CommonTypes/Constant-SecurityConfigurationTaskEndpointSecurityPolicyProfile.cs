// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityConfigurationTaskEndpointSecurityPolicyProfileConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Antivirus")]
    @antivirus,

    [Description("WindowsSecurity")]
    @windowsSecurity,

    [Description("BitLocker")]
    @bitLocker,

    [Description("FileVault")]
    @fileVault,

    [Description("Firewall")]
    @firewall,

    [Description("FirewallRules")]
    @firewallRules,

    [Description("EndpointDetectionAndResponse")]
    @endpointDetectionAndResponse,

    [Description("DeviceControl")]
    @deviceControl,

    [Description("AppAndBrowserIsolation")]
    @appAndBrowserIsolation,

    [Description("ExploitProtection")]
    @exploitProtection,

    [Description("WebProtection")]
    @webProtection,

    [Description("ApplicationControl")]
    @applicationControl,

    [Description("AttackSurfaceReductionRules")]
    @attackSurfaceReductionRules,

    [Description("AccountProtection")]
    @accountProtection,
}
