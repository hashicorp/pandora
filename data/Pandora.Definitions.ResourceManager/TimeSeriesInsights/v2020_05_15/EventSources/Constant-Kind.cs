using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.EventSources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("Microsoft.EventHub")]
    MicrosoftPointEventHub,

    [Description("Microsoft.IoTHub")]
    MicrosoftPointIoTHub,
}
