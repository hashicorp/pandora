using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.ServerEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerProvisioningStatusConstant
{
    [Description("Error")]
    Error,

    [Description("InProgress")]
    InProgress,

    [Description("NotStarted")]
    NotStarted,

    [Description("Ready_SyncFunctional")]
    ReadySyncFunctional,

    [Description("Ready_SyncNotFunctional")]
    ReadySyncNotFunctional,
}
