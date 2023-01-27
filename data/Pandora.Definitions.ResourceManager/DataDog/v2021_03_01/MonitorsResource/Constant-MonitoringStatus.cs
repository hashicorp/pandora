using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.MonitorsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitoringStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
