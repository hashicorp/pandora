using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.MonitorsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiftrResourceCategoriesConstant
{
    [Description("MonitorLogs")]
    MonitorLogs,

    [Description("Unknown")]
    Unknown,
}
