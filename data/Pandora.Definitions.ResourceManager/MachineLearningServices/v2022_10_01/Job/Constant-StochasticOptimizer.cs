using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StochasticOptimizerConstant
{
    [Description("Adam")]
    Adam,

    [Description("Adamw")]
    Adamw,

    [Description("None")]
    None,

    [Description("Sgd")]
    Sgd,
}
