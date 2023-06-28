using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.KafkaConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventStreamingStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
