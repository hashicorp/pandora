using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.SnapshotPolicyListVolumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeStorageToNetworkProximityConstant
{
    [Description("Default")]
    Default,

    [Description("T1")]
    TOne,

    [Description("T2")]
    TTwo,
}
