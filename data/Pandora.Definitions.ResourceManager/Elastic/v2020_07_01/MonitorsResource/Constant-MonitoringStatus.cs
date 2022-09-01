using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitoringStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
