using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StreamOptionsFlagConstant
{
    [Description("Default")]
    Default,

    [Description("LowLatency")]
    LowLatency,

    [Description("LowLatencyV2")]
    LowLatencyVTwo,
}
