using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomParameterTypeConstant
{
    [Description("Bool")]
    Bool,

    [Description("Object")]
    Object,

    [Description("String")]
    String,
}
