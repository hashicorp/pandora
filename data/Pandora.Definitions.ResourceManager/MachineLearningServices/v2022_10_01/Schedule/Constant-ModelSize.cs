using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ModelSizeConstant
{
    [Description("ExtraLarge")]
    ExtraLarge,

    [Description("Large")]
    Large,

    [Description("Medium")]
    Medium,

    [Description("None")]
    None,

    [Description("Small")]
    Small,
}
