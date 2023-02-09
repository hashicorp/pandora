using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerEndpointOfflineDataTransferStateConstant
{
    [Description("Complete")]
    Complete,

    [Description("InProgress")]
    InProgress,

    [Description("NotRunning")]
    NotRunning,

    [Description("Stopping")]
    Stopping,
}
