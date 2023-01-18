using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentNetworkHealth;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationServiceEnvironmentNetworkDependencyCategoryTypeConstant
{
    [Description("AccessEndpoints")]
    AccessEndpoints,

    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("AzureManagement")]
    AzureManagement,

    [Description("AzureStorage")]
    AzureStorage,

    [Description("DiagnosticLogsAndMetrics")]
    DiagnosticLogsAndMetrics,

    [Description("IntegrationServiceEnvironmentConnectors")]
    IntegrationServiceEnvironmentConnectors,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("RecoveryService")]
    RecoveryService,

    [Description("RedisCache")]
    RedisCache,

    [Description("RegionalService")]
    RegionalService,

    [Description("SQL")]
    SQL,

    [Description("SSLCertificateVerification")]
    SSLCertificateVerification,
}
