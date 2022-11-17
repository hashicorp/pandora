using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.WorkloadNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DhcpTypeEnumConstant
{
    [Description("RELAY")]
    RELAY,

    [Description("SERVER")]
    SERVER,
}
