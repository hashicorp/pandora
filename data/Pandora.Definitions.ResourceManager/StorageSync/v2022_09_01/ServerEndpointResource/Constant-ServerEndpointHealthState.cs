using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.ServerEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerEndpointHealthStateConstant
{
    [Description("Error")]
    Error,

    [Description("Healthy")]
    Healthy,

    [Description("Unavailable")]
    Unavailable,
}
