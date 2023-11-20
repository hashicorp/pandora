using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.ApplicationGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetricIdConstant
{
    [Description("IncomingBytes")]
    IncomingBytes,

    [Description("IncomingMessages")]
    IncomingMessages,

    [Description("OutgoingBytes")]
    OutgoingBytes,

    [Description("OutgoingMessages")]
    OutgoingMessages,
}
