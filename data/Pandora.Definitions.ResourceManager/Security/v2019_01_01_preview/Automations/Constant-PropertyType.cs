using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PropertyTypeConstant
{
    [Description("Boolean")]
    Boolean,

    [Description("Integer")]
    Integer,

    [Description("Number")]
    Number,

    [Description("String")]
    String,
}
