using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HighAvailabilityStateConstant
{
    [Description("CreatingStandby")]
    CreatingStandby,

    [Description("FailingOver")]
    FailingOver,

    [Description("Healthy")]
    Healthy,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("RemovingStandby")]
    RemovingStandby,
}
