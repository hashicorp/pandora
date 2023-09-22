using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicyDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ParameterTypeConstant
{
    [Description("Array")]
    Array,

    [Description("Boolean")]
    Boolean,

    [Description("DateTime")]
    DateTime,

    [Description("Float")]
    Float,

    [Description("Integer")]
    Integer,

    [Description("Object")]
    Object,

    [Description("String")]
    String,
}
