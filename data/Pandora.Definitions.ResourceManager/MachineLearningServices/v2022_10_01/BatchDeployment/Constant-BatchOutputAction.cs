using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BatchOutputActionConstant
{
    [Description("AppendRow")]
    AppendRow,

    [Description("SummaryOnly")]
    SummaryOnly,
}
