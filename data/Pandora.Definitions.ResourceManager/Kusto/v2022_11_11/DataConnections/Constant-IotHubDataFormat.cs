using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IotHubDataFormatConstant
{
    [Description("APACHEAVRO")]
    APACHEAVRO,

    [Description("AVRO")]
    AVRO,

    [Description("CSV")]
    CSV,

    [Description("JSON")]
    JSON,

    [Description("MULTIJSON")]
    MULTIJSON,

    [Description("ORC")]
    ORC,

    [Description("PARQUET")]
    PARQUET,

    [Description("PSV")]
    PSV,

    [Description("RAW")]
    RAW,

    [Description("SCSV")]
    SCSV,

    [Description("SINGLEJSON")]
    SINGLEJSON,

    [Description("SOHSV")]
    SOHSV,

    [Description("TSV")]
    TSV,

    [Description("TSVE")]
    TSVE,

    [Description("TXT")]
    TXT,

    [Description("W3CLOGFILE")]
    WThreeCLOGFILE,
}
