using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.SessionHost;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Available")]
    Available,

    [Description("Disconnected")]
    Disconnected,

    [Description("DomainTrustRelationshipLost")]
    DomainTrustRelationshipLost,

    [Description("FSLogixNotHealthy")]
    FSLogixNotHealthy,

    [Description("NeedsAssistance")]
    NeedsAssistance,

    [Description("NoHeartbeat")]
    NoHeartbeat,

    [Description("NotJoinedToDomain")]
    NotJoinedToDomain,

    [Description("Shutdown")]
    Shutdown,

    [Description("SxSStackListenerNotReady")]
    SxSStackListenerNotReady,

    [Description("Unavailable")]
    Unavailable,

    [Description("UpgradeFailed")]
    UpgradeFailed,

    [Description("Upgrading")]
    Upgrading,
}
