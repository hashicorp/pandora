using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LanguageExtensionImageNameConstant
{
    [Description("Python3_9_12")]
    PythonThreeNineOneTwo,

    [Description("Python3_9_12IncludeDeepLearning")]
    PythonThreeNineOneTwoIncludeDeepLearning,

    [Description("Python3_10_8")]
    PythonThreeOneZeroEight,

    [Description("Python3_6_5")]
    PythonThreeSixFive,

    [Description("R")]
    R,
}
