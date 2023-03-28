using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.AgentPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("TCP")]
    TCP,

    [Description("UDP")]
    UDP,
}
