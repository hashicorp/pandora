using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_03_01.JobDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CopyModeConstant
{
    [Description("Additive")]
    Additive,

    [Description("Mirror")]
    Mirror,
}
