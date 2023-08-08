using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.WorkloadNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DhcpTypeEnumConstant
{
    [Description("RELAY")]
    RELAY,

    [Description("SERVER")]
    SERVER,
}
