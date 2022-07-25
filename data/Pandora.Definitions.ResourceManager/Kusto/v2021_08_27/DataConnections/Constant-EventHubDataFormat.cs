using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventHubDataFormatConstant
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
