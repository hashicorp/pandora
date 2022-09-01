using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_03_01.ContainerInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GpuSkuConstant
{
    [Description("K80")]
    KEightZero,

    [Description("P100")]
    POneHundred,

    [Description("V100")]
    VOneHundred,
}
