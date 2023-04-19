using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutosaveConstant
{
    [Description("Local")]
    Local,

    [Description("None")]
    None,

    [Description("Remote")]
    Remote,
}
