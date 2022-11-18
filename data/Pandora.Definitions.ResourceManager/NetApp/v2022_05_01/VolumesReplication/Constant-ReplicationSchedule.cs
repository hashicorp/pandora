using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.VolumesReplication;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationScheduleConstant
{
    [Description("daily")]
    Daily,

    [Description("hourly")]
    Hourly,

    [Description("_10minutely")]
    OneZerominutely,
}
