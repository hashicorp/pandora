using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeStorageToNetworkProximityConstant
{
    [Description("AcrossT2")]
    AcrossTTwo,

    [Description("Default")]
    Default,

    [Description("T1")]
    TOne,

    [Description("T2")]
    TTwo,
}
