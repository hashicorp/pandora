using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SolutionTypeConstant
{
    [Description("BestPractices")]
    BestPractices,

    [Description("DeepInvestigation")]
    DeepInvestigation,

    [Description("QuickSolution")]
    QuickSolution,
}
