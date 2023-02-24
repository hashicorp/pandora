using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Pipelines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VariableTypeConstant
{
    [Description("Array")]
    Array,

    [Description("Bool")]
    Bool,

    [Description("String")]
    String,
}
