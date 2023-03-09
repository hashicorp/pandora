using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AttributeFilterConstant
{
    [Description("All")]
    All,

    [Description("Bottom")]
    Bottom,

    [Description("Top")]
    Top,

    [Description("ValueEquals")]
    ValueEquals,
}
