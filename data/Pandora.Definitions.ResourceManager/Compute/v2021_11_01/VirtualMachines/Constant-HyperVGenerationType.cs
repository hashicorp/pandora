using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HyperVGenerationTypeConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
