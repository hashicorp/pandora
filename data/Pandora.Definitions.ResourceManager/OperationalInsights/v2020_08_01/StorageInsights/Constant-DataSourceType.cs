using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.StorageInsights;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSourceTypeConstant
{
    [Description("Alerts")]
    Alerts,

    [Description("AzureWatson")]
    AzureWatson,

    [Description("CustomLogs")]
    CustomLogs,

    [Description("Ingestion")]
    Ingestion,

    [Description("Query")]
    Query,
}
