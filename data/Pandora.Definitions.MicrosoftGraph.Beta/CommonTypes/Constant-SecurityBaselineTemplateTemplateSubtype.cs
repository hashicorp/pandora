// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityBaselineTemplateTemplateSubtypeConstant
{
    [Description("None")]
    @none,

    [Description("Firewall")]
    @firewall,

    [Description("DiskEncryption")]
    @diskEncryption,

    [Description("AttackSurfaceReduction")]
    @attackSurfaceReduction,

    [Description("EndpointDetectionReponse")]
    @endpointDetectionReponse,

    [Description("AccountProtection")]
    @accountProtection,

    [Description("Antivirus")]
    @antivirus,

    [Description("FirewallSharedAppList")]
    @firewallSharedAppList,

    [Description("FirewallSharedIpList")]
    @firewallSharedIpList,

    [Description("FirewallSharedPortlist")]
    @firewallSharedPortlist,
}
