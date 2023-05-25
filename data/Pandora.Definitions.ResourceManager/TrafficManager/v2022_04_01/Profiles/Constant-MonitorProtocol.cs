using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2022_04_01.Profiles;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitorProtocolConstant
{
    [Description("HTTP")]
    HTTP,

    [Description("HTTPS")]
    HTTPS,

    [Description("TCP")]
    TCP,
}
