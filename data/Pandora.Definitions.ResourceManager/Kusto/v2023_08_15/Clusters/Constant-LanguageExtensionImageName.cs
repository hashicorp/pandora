using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LanguageExtensionImageNameConstant
{
    [Description("PythonCustomImage")]
    PythonCustomImage,

    [Description("Python3_10_8")]
    PythonThreeOneZeroEight,

    [Description("Python3_10_8_DL")]
    PythonThreeOneZeroEightDL,

    [Description("Python3_6_5")]
    PythonThreeSixFive,

    [Description("R")]
    R,
}
