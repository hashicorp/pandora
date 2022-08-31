using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HyperVGenerationTypesConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
