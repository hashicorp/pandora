using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EvaluationStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("InProgress")]
    InProgress,

    [Description("NotStarted")]
    NotStarted,
}
