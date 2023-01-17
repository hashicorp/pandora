using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventSerializationTypeConstant
{
    [Description("Avro")]
    Avro,

    [Description("Csv")]
    Csv,

    [Description("CustomClr")]
    CustomClr,

    [Description("Delta")]
    Delta,

    [Description("Json")]
    Json,

    [Description("Parquet")]
    Parquet,
}
