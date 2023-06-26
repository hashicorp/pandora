using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/scripts")]
    MicrosoftPointKustoClustersDatabasesScripts,
}
