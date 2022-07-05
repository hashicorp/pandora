using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventSerializationTypeConstant
{
    [Description("Avro")]
    Avro,

    [Description("Csv")]
    Csv,

    [Description("Json")]
    Json,

    [Description("Parquet")]
    Parquet,
}
