using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FilterModeConstant
{
    [Description("Default")]
    Default,

    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,

    [Description("Recommend")]
    Recommend,
}
