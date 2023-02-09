using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.EventSources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LocalTimestampFormatConstant
{
    [Description("Embedded")]
    Embedded,
}
