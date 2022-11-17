using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OnlineDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleTypeConstant
{
    [Description("Default")]
    Default,

    [Description("TargetUtilization")]
    TargetUtilization,
}
