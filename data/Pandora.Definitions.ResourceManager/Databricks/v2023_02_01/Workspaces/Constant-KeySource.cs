using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Default")]
    Default,

    [Description("Microsoft.Keyvault")]
    MicrosoftPointKeyvault,
}
