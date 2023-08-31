using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KubernetesPluginTypeConstant
{
    [Description("DPDK")]
    DPDK,

    [Description("IPVLAN")]
    IPVLAN,

    [Description("MACVLAN")]
    MACVLAN,

    [Description("OSDevice")]
    OSDevice,

    [Description("SRIOV")]
    SRIOV,
}
