using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.PublishedBlueprint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TemplateParameterTypeConstant
{
    [Description("array")]
    Array,

    [Description("bool")]
    Bool,

    [Description("int")]
    Int,

    [Description("object")]
    Object,

    [Description("secureObject")]
    SecureObject,

    [Description("secureString")]
    SecureString,

    [Description("string")]
    String,
}
