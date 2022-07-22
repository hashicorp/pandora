using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.Experiments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelectorTypeConstant
{
    [Description("List")]
    List,

    [Description("Percent")]
    Percent,

    [Description("Random")]
    Random,

    [Description("Tag")]
    Tag,
}
