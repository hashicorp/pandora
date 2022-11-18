using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EarlyTerminationPolicyTypeConstant
{
    [Description("Bandit")]
    Bandit,

    [Description("MedianStopping")]
    MedianStopping,

    [Description("TruncationSelection")]
    TruncationSelection,
}
