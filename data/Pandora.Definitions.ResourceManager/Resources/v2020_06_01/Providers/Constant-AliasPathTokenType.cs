using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Providers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AliasPathTokenTypeConstant
{
    [Description("Any")]
    Any,

    [Description("Array")]
    Array,

    [Description("Boolean")]
    Boolean,

    [Description("Integer")]
    Integer,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Number")]
    Number,

    [Description("Object")]
    Object,

    [Description("String")]
    String,
}
