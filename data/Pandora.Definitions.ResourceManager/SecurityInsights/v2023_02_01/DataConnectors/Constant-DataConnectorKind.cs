using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.DataConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectorKindConstant
{
    [Description("AmazonWebServicesCloudTrail")]
    AmazonWebServicesCloudTrail,

    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("AzureAdvancedThreatProtection")]
    AzureAdvancedThreatProtection,

    [Description("AzureSecurityCenter")]
    AzureSecurityCenter,

    [Description("MicrosoftCloudAppSecurity")]
    MicrosoftCloudAppSecurity,

    [Description("MicrosoftDefenderAdvancedThreatProtection")]
    MicrosoftDefenderAdvancedThreatProtection,

    [Description("Office365")]
    OfficeThreeSixFive,

    [Description("ThreatIntelligence")]
    ThreatIntelligence,
}
