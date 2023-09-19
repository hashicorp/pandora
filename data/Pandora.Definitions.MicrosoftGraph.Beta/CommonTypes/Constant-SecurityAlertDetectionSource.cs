// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityAlertDetectionSourceConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("MicrosoftDefenderForEndpoint")]
    @microsoftDefenderForEndpoint,

    [Description("Antivirus")]
    @antivirus,

    [Description("SmartScreen")]
    @smartScreen,

    [Description("CustomTi")]
    @customTi,

    [Description("MicrosoftDefenderForOffice365")]
    @microsoftDefenderForOffice365,

    [Description("AutomatedInvestigation")]
    @automatedInvestigation,

    [Description("MicrosoftThreatExperts")]
    @microsoftThreatExperts,

    [Description("CustomDetection")]
    @customDetection,

    [Description("MicrosoftDefenderForIdentity")]
    @microsoftDefenderForIdentity,

    [Description("CloudAppSecurity")]
    @cloudAppSecurity,

    [Description("Microsoft365Defender")]
    @microsoft365Defender,

    [Description("AzureAdIdentityProtection")]
    @azureAdIdentityProtection,

    [Description("Manual")]
    @manual,

    [Description("MicrosoftDataLossPrevention")]
    @microsoftDataLossPrevention,

    [Description("AppGovernancePolicy")]
    @appGovernancePolicy,

    [Description("AppGovernanceDetection")]
    @appGovernanceDetection,

    [Description("MicrosoftDefenderForCloud")]
    @microsoftDefenderForCloud,
}
