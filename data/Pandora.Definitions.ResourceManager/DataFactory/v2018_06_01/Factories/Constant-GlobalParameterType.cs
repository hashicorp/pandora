using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Factories;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GlobalParameterTypeConstant
{
    [Description("Array")]
    Array,

    [Description("Bool")]
    Bool,

    [Description("Float")]
    Float,

    [Description("Int")]
    Int,

    [Description("Object")]
    Object,

    [Description("String")]
    String,
}
