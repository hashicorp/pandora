using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HyperVGenerationTypesConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
