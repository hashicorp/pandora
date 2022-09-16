using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectionTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/dataConnections")]
    MicrosoftPointKustoClustersDatabasesDataConnections,
}
