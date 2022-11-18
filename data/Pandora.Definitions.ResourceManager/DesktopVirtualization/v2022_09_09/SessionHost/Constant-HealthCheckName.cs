using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.SessionHost;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthCheckNameConstant
{
    [Description("AppAttachHealthCheck")]
    AppAttachHealthCheck,

    [Description("DomainJoinedCheck")]
    DomainJoinedCheck,

    [Description("DomainReachable")]
    DomainReachable,

    [Description("DomainTrustCheck")]
    DomainTrustCheck,

    [Description("FSLogixHealthCheck")]
    FSLogixHealthCheck,

    [Description("MetaDataServiceCheck")]
    MetaDataServiceCheck,

    [Description("MonitoringAgentCheck")]
    MonitoringAgentCheck,

    [Description("SupportedEncryptionCheck")]
    SupportedEncryptionCheck,

    [Description("SxSStackListenerCheck")]
    SxSStackListenerCheck,

    [Description("UrlsAccessibleCheck")]
    UrlsAccessibleCheck,

    [Description("WebRTCRedirectorCheck")]
    WebRTCRedirectorCheck,
}
