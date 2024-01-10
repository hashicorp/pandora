// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityBaselineTemplateTemplateTypeConstant
{
    [Description("SecurityBaseline")]
    @securityBaseline,

    [Description("SpecializedDevices")]
    @specializedDevices,

    [Description("AdvancedThreatProtectionSecurityBaseline")]
    @advancedThreatProtectionSecurityBaseline,

    [Description("DeviceConfiguration")]
    @deviceConfiguration,

    [Description("Custom")]
    @custom,

    [Description("SecurityTemplate")]
    @securityTemplate,

    [Description("MicrosoftEdgeSecurityBaseline")]
    @microsoftEdgeSecurityBaseline,

    [Description("MicrosoftOffice365ProPlusSecurityBaseline")]
    @microsoftOffice365ProPlusSecurityBaseline,

    [Description("DeviceCompliance")]
    @deviceCompliance,

    [Description("DeviceConfigurationForOffice365")]
    @deviceConfigurationForOffice365,

    [Description("CloudPC")]
    @cloudPC,

    [Description("FirewallSharedSettings")]
    @firewallSharedSettings,
}
