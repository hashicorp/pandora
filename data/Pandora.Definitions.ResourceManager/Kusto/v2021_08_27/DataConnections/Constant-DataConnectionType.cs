using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectionTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/dataConnections")]
    MicrosoftPointKustoClustersDatabasesDataConnections,
}
