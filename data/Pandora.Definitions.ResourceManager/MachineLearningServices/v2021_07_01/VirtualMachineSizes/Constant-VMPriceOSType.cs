using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.VirtualMachineSizes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMPriceOSTypeConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
