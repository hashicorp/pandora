// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

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

    [Description("MicrosoftDefenderForIoT")]
    @microsoftDefenderForIoT,

    [Description("MicrosoftDefenderForServers")]
    @microsoftDefenderForServers,

    [Description("MicrosoftDefenderForStorage")]
    @microsoftDefenderForStorage,

    [Description("MicrosoftDefenderForDNS")]
    @microsoftDefenderForDNS,

    [Description("MicrosoftDefenderForDatabases")]
    @microsoftDefenderForDatabases,

    [Description("MicrosoftDefenderForContainers")]
    @microsoftDefenderForContainers,

    [Description("MicrosoftDefenderForNetwork")]
    @microsoftDefenderForNetwork,

    [Description("MicrosoftDefenderForAppService")]
    @microsoftDefenderForAppService,

    [Description("MicrosoftDefenderForKeyVault")]
    @microsoftDefenderForKeyVault,

    [Description("MicrosoftDefenderForResourceManager")]
    @microsoftDefenderForResourceManager,

    [Description("MicrosoftDefenderForApiManagement")]
    @microsoftDefenderForApiManagement,

    [Description("NrtAlerts")]
    @nrtAlerts,

    [Description("ScheduledAlerts")]
    @scheduledAlerts,

    [Description("MicrosoftDefenderThreatIntelligenceAnalytics")]
    @microsoftDefenderThreatIntelligenceAnalytics,

    [Description("BuiltInMl")]
    @builtInMl,

    [Description("MicrosoftSentinel")]
    @microsoftSentinel,
}
