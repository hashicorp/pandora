using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2022_06_01.MonitorsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiftrResourceCategoriesConstant
{
    [Description("MonitorLogs")]
    MonitorLogs,

    [Description("Unknown")]
    Unknown,
}
