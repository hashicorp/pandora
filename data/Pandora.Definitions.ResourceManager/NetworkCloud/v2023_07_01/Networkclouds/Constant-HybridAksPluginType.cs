using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HybridAksPluginTypeConstant
{
    [Description("DPDK")]
    DPDK,

    [Description("OSDevice")]
    OSDevice,

    [Description("SRIOV")]
    SRIOV,
}
