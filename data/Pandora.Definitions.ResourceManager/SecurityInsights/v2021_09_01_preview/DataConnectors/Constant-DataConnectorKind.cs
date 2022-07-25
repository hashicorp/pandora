using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.DataConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectorKindConstant
{
    [Description("APIPolling")]
    APIPolling,

    [Description("AmazonWebServicesCloudTrail")]
    AmazonWebServicesCloudTrail,

    [Description("AmazonWebServicesS3")]
    AmazonWebServicesSThree,

    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("AzureAdvancedThreatProtection")]
    AzureAdvancedThreatProtection,

    [Description("AzureSecurityCenter")]
    AzureSecurityCenter,

    [Description("Dynamics365")]
    DynamicsThreeSixFive,

    [Description("GenericUI")]
    GenericUI,

    [Description("MicrosoftCloudAppSecurity")]
    MicrosoftCloudAppSecurity,

    [Description("MicrosoftDefenderAdvancedThreatProtection")]
    MicrosoftDefenderAdvancedThreatProtection,

    [Description("MicrosoftThreatIntelligence")]
    MicrosoftThreatIntelligence,

    [Description("MicrosoftThreatProtection")]
    MicrosoftThreatProtection,

    [Description("OfficeATP")]
    OfficeATP,

    [Description("OfficeIRM")]
    OfficeIRM,

    [Description("Office365")]
    OfficeThreeSixFive,

    [Description("ThreatIntelligence")]
    ThreatIntelligence,

    [Description("ThreatIntelligenceTaxii")]
    ThreatIntelligenceTaxii,
}
