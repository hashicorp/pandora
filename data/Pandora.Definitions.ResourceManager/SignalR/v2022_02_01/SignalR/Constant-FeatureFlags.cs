using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2022_02_01.SignalR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureFlagsConstant
{
    [Description("EnableConnectivityLogs")]
    EnableConnectivityLogs,

    [Description("EnableLiveTrace")]
    EnableLiveTrace,

    [Description("EnableMessagingLogs")]
    EnableMessagingLogs,

    [Description("ServiceMode")]
    ServiceMode,
}
