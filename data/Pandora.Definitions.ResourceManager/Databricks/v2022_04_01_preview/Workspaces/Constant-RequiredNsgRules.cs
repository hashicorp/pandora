using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2022_04_01_preview.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RequiredNsgRulesConstant
{
    [Description("AllRules")]
    AllRules,

    [Description("NoAzureDatabricksRules")]
    NoAzureDatabricksRules,

    [Description("NoAzureServiceRules")]
    NoAzureServiceRules,
}
