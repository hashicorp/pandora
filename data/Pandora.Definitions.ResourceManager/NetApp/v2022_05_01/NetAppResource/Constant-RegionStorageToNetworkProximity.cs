using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.NetAppResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegionStorageToNetworkProximityConstant
{
    [Description("Default")]
    Default,

    [Description("T1")]
    TOne,

    [Description("T1AndT2")]
    TOneAndTTwo,

    [Description("T2")]
    TTwo,
}
