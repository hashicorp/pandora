using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/scripts")]
    MicrosoftPointKustoClustersDatabasesScripts,
}
