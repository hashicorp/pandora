using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Disks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HyperVGenerationConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
