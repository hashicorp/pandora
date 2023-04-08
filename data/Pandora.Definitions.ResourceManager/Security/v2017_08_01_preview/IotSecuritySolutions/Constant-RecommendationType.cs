using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IotSecuritySolutions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationTypeConstant
{
    [Description("IoT_ACRAuthentication")]
    IoTACRAuthentication,

    [Description("IoT_AgentSendsUnutilizedMessages")]
    IoTAgentSendsUnutilizedMessages,

    [Description("IoT_Baseline")]
    IoTBaseline,

    [Description("IoT_EdgeHubMemOptimize")]
    IoTEdgeHubMemOptimize,

    [Description("IoT_EdgeLoggingOptions")]
    IoTEdgeLoggingOptions,

    [Description("IoT_IPFilter_DenyAll")]
    IoTIPFilterDenyAll,

    [Description("IoT_IPFilter_PermissiveRule")]
    IoTIPFilterPermissiveRule,

    [Description("IoT_InconsistentModuleSettings")]
    IoTInconsistentModuleSettings,

    [Description("IoT_InstallAgent")]
    IoTInstallAgent,

    [Description("IoT_OpenPorts")]
    IoTOpenPorts,

    [Description("IoT_PermissiveFirewallPolicy")]
    IoTPermissiveFirewallPolicy,

    [Description("IoT_PermissiveInputFirewallRules")]
    IoTPermissiveInputFirewallRules,

    [Description("IoT_PermissiveOutputFirewallRules")]
    IoTPermissiveOutputFirewallRules,

    [Description("IoT_PrivilegedDockerOptions")]
    IoTPrivilegedDockerOptions,

    [Description("IoT_SharedCredentials")]
    IoTSharedCredentials,

    [Description("IoT_VulnerableTLSCipherSuite")]
    IoTVulnerableTLSCipherSuite,
}
