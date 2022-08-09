using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.IncrementalRestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HyperVGenerationConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
