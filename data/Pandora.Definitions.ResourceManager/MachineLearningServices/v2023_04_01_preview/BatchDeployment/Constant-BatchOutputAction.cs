using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.BatchDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BatchOutputActionConstant
{
    [Description("AppendRow")]
    AppendRow,

    [Description("SummaryOnly")]
    SummaryOnly,
}
