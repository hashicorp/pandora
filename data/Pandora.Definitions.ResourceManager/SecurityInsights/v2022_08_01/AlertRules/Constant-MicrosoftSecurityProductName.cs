using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MicrosoftSecurityProductNameConstant
{
    [Description("Azure Active Directory Identity Protection")]
    AzureActiveDirectoryIdentityProtection,

    [Description("Azure Advanced Threat Protection")]
    AzureAdvancedThreatProtection,

    [Description("Azure Security Center")]
    AzureSecurityCenter,

    [Description("Azure Security Center for IoT")]
    AzureSecurityCenterForIoT,

    [Description("Microsoft Cloud App Security")]
    MicrosoftCloudAppSecurity,
}
