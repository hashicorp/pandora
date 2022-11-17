using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2022_09_01.ContainerInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerGroupSkuConstant
{
    [Description("Dedicated")]
    Dedicated,

    [Description("Standard")]
    Standard,
}
