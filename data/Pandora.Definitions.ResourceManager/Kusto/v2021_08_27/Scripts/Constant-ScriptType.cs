using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/scripts")]
    MicrosoftPointKustoClustersDatabasesScripts,
}
